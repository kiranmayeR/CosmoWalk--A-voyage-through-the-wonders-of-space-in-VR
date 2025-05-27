using UnityEngine;
using UnityEngine.XR;

public class SpaceshipControl : MonoBehaviour
{
    public float speed = 2.0f;  // Movement speed
    public Transform cameraTransform; // Assign Main Camera (usually inside XR Rig)

    void Update()
    {
        // Get input from the left-hand controller's thumbstick
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 input))
        {
            // Calculate direction based on camera orientation (to move relative to where user is looking)
            Vector3 direction = cameraTransform.forward * input.y + cameraTransform.right * input.x;
            direction.y = 0f; // Keep movement horizontal
            direction.Normalize();

            // Move the spaceship
            transform.position += direction * speed * Time.deltaTime;

            Debug.Log($"Thumbstick: {input}, Direction: {direction}");
        }
    }
}