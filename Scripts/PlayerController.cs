using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float drag = 3f;
    public float snapTurnAngle = 45f;

    private Rigidbody rb;
    private Vector3 currentDirection = Vector3.zero;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = drag;  // Smooth stopping
    }

    void FixedUpdate()
    {
        if (currentDirection != Vector3.zero)
        {
            rb.AddForce(currentDirection * moveForce);
        }

        
    }

    // Button press functions
    public void MoveForward() => currentDirection = transform.forward;
    public void MoveBackward() => currentDirection = -transform.forward;
    public void MoveLeft() => currentDirection = -transform.right;
    public void MoveRight() => currentDirection = transform.right;
    public void MoveUp() => currentDirection = transform.up;
    public void MoveDown() => currentDirection = -transform.up;

    // Button release
    public void StopMovement() => currentDirection = Vector3.zero;

    // Snap Turn (called once per button press)
    public void SnapTurnRight() => transform.Rotate(Vector3.up * snapTurnAngle);
    public void SnapTurnLeft() => transform.Rotate(Vector3.up * -snapTurnAngle);

}
