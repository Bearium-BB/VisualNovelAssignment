using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerDragController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask draggableMask = 0;

    InputSystem_Actions controls;

    IDragable current;
    RectTransform uiRect;
    Camera uiCam;
    Plane dragPlane;

    readonly List<RaycastResult> uiHits = new();
    PointerEventData pointerData;

    //Setting up inputs
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
    void Awake() => controls = new InputSystem_Actions();
    void OnEnable() => controls.UI.Enable();
    void OnDisable() => controls.UI.Disable();
    void OnDestroy() => controls.Dispose();

    void Update()
    {
        Vector2 screenPos = controls.UI.Point.ReadValue<Vector2>();
        InputAction click = controls.UI.Click;

        //We'll try to pick something up if the mouse was pressed. 
        if (click.WasPressedThisFrame())
            TryPickUp(screenPos);
        
        //If we're currently dragging something, we'll update its position.
        if (current != null && click.IsPressed() && TryGetDragPoint(screenPos, out Vector3 pos))
            current.OnDrag(pos);
        
        //If the mouse was released, we'll end the drag.
        if (current != null && click.WasReleasedThisFrame())
        {
            current.OnDragEnd();
            current = null;
            uiRect = null;
        }
    }

    void TryPickUp(Vector2 screenPos)
    {
        // We'll check if the mouse is over a UI element first.
        if (EventSystem.current != null)
        {
            // We'll check if the mouse is over a UI element first.
            pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = screenPos;
            uiHits.Clear();
            EventSystem.current.RaycastAll(pointerData, uiHits);

            // If we hit a UI element, we'll try to get the IDragable component from it.
            if (uiHits.Count > 0)
            {
                RaycastResult top = uiHits[0]; 
                IDragable dragable = top.gameObject.GetComponentInParent<IDragable>();
                if (dragable == null) return;

                // We'll store the RectTransform and Camera for the UI element so we can use them later.
                uiRect = ((Component)dragable).transform as RectTransform;
                uiCam = top.module.eventCamera;

                // We'll convert the screen position to a world position and start the drag.
                if (uiRect != null && RectTransformUtility.ScreenPointToWorldPointInRectangle(uiRect, screenPos, uiCam, out Vector3 pos))
                {
                    current = dragable;
                    current.OnDragStart(pos);
                }
                return;
            }
        }
        // If we didn't hit a UI element, we'll try to pick up a world object.
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 1000f, draggableMask);

        // If we hit a world object, we'll start the drag.
        if (hit2D.collider != null)
        {
            Vector3 point = new Vector3(hit2D.point.x, hit2D.point.y, hit2D.transform.position.z);
            StartWorldDrag(hit2D.collider.GetComponentInParent<IDragable>(), point);
        }
    }
    // We'll start dragging a world object by setting the current dragable, the drag plane, and calling OnDragStart.
    void StartWorldDrag(IDragable dragable, Vector3 hitPoint)
    {
        if (dragable == null) return;
        current = dragable;
        uiRect = null;
        dragPlane = new Plane(-cam.transform.forward, hitPoint);
        current.OnDragStart(hitPoint);
    }

    // We'll try to get the world position of the mouse cursor. If we're dragging a UI element, we'll use RectTransformUtility. If we're dragging a world object, we'll use a raycast against the drag plane.
    bool TryGetDragPoint(Vector2 screenPos, out Vector3 point)
    {
        // If we're dragging a UI element, we'll use RectTransformUtility to get the world position of the mouse cursor.
        if (uiRect != null)
            return RectTransformUtility.ScreenPointToWorldPointInRectangle(uiRect, screenPos, uiCam, out point);


        Ray ray = cam.ScreenPointToRay(screenPos);

        // If we're dragging a world object, we'll use a raycast against the drag plane to get the world position of the mouse cursor.

        if (dragPlane.Raycast(ray, out float dist))
        {
            point = ray.GetPoint(dist);
            return true;
        }

        point = Vector3.zero;

        return false;
    }
}