using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class XRShipController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float drag = 3f;
    public float snapTurnAngle = 45f;

    [Header("Input Actions")]
    public InputActionProperty moveAction; // Vector2 (thumbstick)
    public InputActionProperty snapTurnClickAction; // Button (thumbstickClicked)

    private Rigidbody rb;
    private bool hasTurnedThisClick = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = drag;

        moveAction.action.Enable();
        snapTurnClickAction.action.Enable();
    }

    void FixedUpdate()
    {
        Vector2 inputVector = moveAction.action.ReadValue<Vector2>();

        // Move forward/backward/strafe
        Vector3 moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        rb.AddForce(moveDirection * moveForce);

        // Snap turn on thumbstick click (optional: only once per click)
        if (snapTurnClickAction.action.IsPressed())
        {
            if (!hasTurnedThisClick)
            {
                if (inputVector.x > 0.5f)
                    transform.Rotate(Vector3.up * snapTurnAngle);
                else if (inputVector.x < -0.5f)
                    transform.Rotate(Vector3.up * -snapTurnAngle);

                hasTurnedThisClick = true;
            }
        }
        else
        {
            hasTurnedThisClick = false;
        }
    }
}