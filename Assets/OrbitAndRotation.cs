using UnityEngine;

public class OrbitAndRotation : MonoBehaviour
{
    public Transform orbitCenter; // The Sun (Set this in Inspector)
    public float orbitSpeed = 10f; // Speed of revolution
    public float selfRotationSpeed = 50f; // Speed of self-rotation

    void Update()
    {
        // Ensure we have a valid orbit center
        if (orbitCenter != null)
        {
            // Make the Empty Object revolve around the Sun
            transform.RotateAround(orbitCenter.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }

        // Make the actual planet (child) rotate on its own axis
        if (transform.childCount > 0)
        {
            Transform planet = transform.GetChild(0); // Get the first child (the actual planet)
            planet.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime);
        }
    }
}
