using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIWorldDropItem : MonoBehaviour, IDragable
{
    [SerializeField] LayerMask dropMask = 0;
    [SerializeField] bool snapBackAfterDrop = true;

    Camera cam;
    Vector3 startPos;

    //Grabbing main camera
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
    void Awake() => cam = Camera.main;

    public void OnDragStart(Vector3 worldPoint)
    {
        startPos = transform.position;
    }

    public void OnDrag(Vector3 worldPoint)
    {
        transform.position = worldPoint;
    }

    // Handling the end of the drag event and checking for drop targets
    public void OnDragEnd()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        // Checking for 2D drop targets
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 1000f, dropMask);
        if (hit2D.collider != null)
            HandleDrop(hit2D.collider.gameObject, hit2D.point);

        // If no drop target was hit, snap back to the original position if required
        if (snapBackAfterDrop)
            transform.position = startPos;
    }

    // Handling the drop event and notifying the target
    void HandleDrop(GameObject target, Vector3 worldPoint)
    {
        Debug.Log($"Dropped {name} on {target.name} at {worldPoint}");

        // Notify the target if it implements IDropTarget
        target.GetComponentInParent<IDropTarget>()?.OnDropped(this, worldPoint);
    }
}
