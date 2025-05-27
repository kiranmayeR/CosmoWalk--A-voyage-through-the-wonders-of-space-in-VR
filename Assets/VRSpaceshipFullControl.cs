using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRSpaceshipFullControl : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float verticalSpeed = 1.5f;
    public float rotationSpeed = 60f;

    private InputDevice rightHand;

    void Start()
    {
        List<InputDevice> rightHandedControllers = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandedControllers);

        if (rightHandedControllers.Count > 0)
        {
            rightHand = rightHandedControllers[0];
        }
    }

    void Update()
    {
        if (!rightHand.isValid)
        {
            // Re-acquire if lost
            List<InputDevice> rightHandedControllers = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandedControllers);
            if (rightHandedControllers.Count > 0)
                rightHand = rightHandedControllers[0];

            return;
        }

        // Get joystick input
        if (rightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputAxis))
        {
            // Move forward/back and strafe
            Vector3 direction = transform.forward * inputAxis.y + transform.right * inputAxis.x;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        // Optional: vertical up/down movement using secondary axis (if mapped)
        if (rightHand.TryGetFeatureValue(CommonUsages.secondary2DAxis, out Vector2 secondaryAxis))
        {
            // Move up/down with vertical axis of secondary joystick
            float verticalMove = secondaryAxis.y * verticalSpeed * Time.deltaTime;
            transform.position += Vector3.up * verticalMove;

            // Optional rotation (yaw)
            float rotateAmount = secondaryAxis.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotateAmount, 0);
        }
    }
}