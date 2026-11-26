using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    InputSystem_Actions controls;
    Vector2 movement;
    public float speed = 5f;
    public float maxX = 18f;
    public float minX = -18f;

    void Awake()
    {
        controls = new InputSystem_Actions();

    }

    void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;

    }

    void OnDisable()
    {
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
        controls.Player.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

    }

    void Update()
    {
        if (GameplayGameManager.instance != null && GameplayGameManager.instance.isBlocking) return;

        float newX = Mathf.Clamp(transform.position.x + movement.x * Time.deltaTime * speed, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
