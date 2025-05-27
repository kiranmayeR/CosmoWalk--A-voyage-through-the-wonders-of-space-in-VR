using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
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
        rb.linearDamping = drag;  // Corrected the property name to 'drag'
    }

    void FixedUpdate()
    {
        if (currentDirection != Vector3.zero)
        {
            // Add force to move the spaceship in the calculated direction.
            rb.AddForce(currentDirection * moveForce, ForceMode.VelocityChange);
        }
    }

    void Update()
    {
        // Get the thumbstick input
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Debug.Log("SecondaryThumbstick " + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick));
        Debug.Log("PrimaryThumbstick " + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick));

        if (thumbstick.magnitude > 0.1f)  // If thumbstick is pushed
        {
            // Calculate the movement direction based on thumbstick input
            Vector3 forward = transform.forward;   // Move forward in relation to the ship's current direction
            Vector3 right = transform.right;       // Strafe right if thumbstick is pushed horizontally

            // Combine forward and right movements from the thumbstick
            currentDirection = (forward * thumbstick.y + right * thumbstick.x).normalized;

            // Log for debugging
            Debug.Log($"Thumbstick: {thumbstick}, Direction: {currentDirection}");
        }
        else
        {
            // If no input, stop the movement
            currentDirection = Vector3.zero;
        }
    }
}