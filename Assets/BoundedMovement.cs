using UnityEngine;

public class CircularBoundaryMovement : MonoBehaviour
{
    public Vector3 center = Vector3.zero; // Center of the circular boundary
    public float radius = 5f; // Radius of the boundary
    public float speed = 2f; // Speed of movement along the boundary
    private float angle = 0f;

    void Update()
    {
        // Increase the angle over time to make the object move along the circular boundary
        angle += (speed / radius) * Time.deltaTime;
        if (angle >= 2 * Mathf.PI) // Reset the angle after a full circle
        {
            angle -= 2 * Mathf.PI;
        }

        // Calculate new position along the circular boundary
        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);

        // Maintain current Y position (so it doesn't sink or float)
        transform.position = new Vector3(x, transform.position.y, z);

        // Make the object face forward along the path
        Vector3 nextPosition = new Vector3(
            center.x + radius * Mathf.Cos(angle + 0.1f),
            transform.position.y,
            center.z + radius * Mathf.Sin(angle + 0.1f)
        );
        transform.LookAt(nextPosition);
    }
}
