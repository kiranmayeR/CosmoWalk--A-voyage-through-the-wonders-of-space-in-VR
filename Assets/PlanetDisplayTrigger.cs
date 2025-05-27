using UnityEngine;
using UnityEngine.UI;

public class PlanetDisplayTrigger : MonoBehaviour
{
    [Header("References")]
    public GameObject shuttle;               // Drag your shuttle GameObject here
    public GameObject screenDisplay;         // The Canvas (screen) inside the shuttle
    public Sprite planetImage;               // The image to show when near this planet

    [Header("Settings")]
    public float triggerDistance = 100f;     // Distance to trigger display

    private Image screenImage;
    private bool hasDisplayed = false;

    void Start()
    {
        // Get the Image component from inside the screen display
        if (screenDisplay != null)
        {
            screenImage = screenDisplay.GetComponentInChildren<Image>();
            screenDisplay.SetActive(false); // Start with screen hidden
        }

        // Optional fallback: try to find shuttle if not manually assigned
        if (shuttle == null)
        {
            shuttle = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        // Check distance only if not already displayed
        if (!hasDisplayed && shuttle != null)
        {
            float distance = Vector3.Distance(transform.position, shuttle.transform.position);

            if (distance <= triggerDistance)
            {
                DisplayPlanetImage();
                hasDisplayed = true;
            }
        }
    }

    void DisplayPlanetImage()
    {
        if (screenDisplay != null && screenImage != null && planetImage != null)
        {
            screenDisplay.SetActive(true);
            screenImage.sprite = planetImage;
        }
    }
}
