using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerPickUpController : MonoBehaviour
{
    [SerializeField] Camera cam;

    InputSystem_Actions controls;

    void Awake() => controls = new InputSystem_Actions();

    void OnEnable()
    {
        controls.UI.Enable();
        controls.UI.Click.performed += OnClick;
    }

    void OnDisable()
    {
        controls.UI.Click.performed -= OnClick;
        controls.UI.Disable();
    }

    void OnClick(InputAction.CallbackContext context)
    {
        // Check if the click is over a UI element
        Vector2 screenPos = controls.UI.Point.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(screenPos);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
        
        // Perform a raycast to check for pickupable objects
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 1000f);
        if (hit.collider == null) return;

        // Check if the hit object has a component that implements IPickUpable
        IPickUpable pickup = hit.collider.GetComponentInParent<IPickUpable>();
        if (pickup != null)
            pickup.OnPickUp();
    }
}
