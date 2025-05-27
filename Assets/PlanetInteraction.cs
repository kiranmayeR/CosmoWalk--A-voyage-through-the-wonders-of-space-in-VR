using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    public Sprite planetImage;  // Assign planet image in Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Use layer or tag comparison, depending on setup
        if (other.CompareTag("spaceship"))
        {
            Debug.Log($"Collision with {other.name}");

            // Attempt to get ShuttleDisplayController directly from children
            ShuttleDisplayController displayController = other.GetComponentInChildren<ShuttleDisplayController>();

            if (displayController != null)
            {
                displayController.ShowPlanetImage(planetImage);
                Debug.Log("Planet image sent to ShuttleDisplayController.");
            }
            else
            {
                Debug.LogWarning("ShuttleDisplayController not found under the spaceship object.");
            }
        }
        else
        {
            Debug.Log($"Ignored collision with object: {other.name}");
        }
    }
}
