using UnityEngine;
using UnityEngine.UI;

public class ShuttleDisplayController : MonoBehaviour
{
    [Header("UI Reference")]
    public Image displayImage;  // Assign this in the Inspector to the Image in your Canvas

    /// <summary>
    /// Shows the given planet image on the shuttle's screen.
    /// </summary>
    /// <param name="planetImage">The sprite of the planet to display.</param>
    public void ShowPlanetImage(Sprite planetImage)
    {
        if (displayImage != null && planetImage != null)
        {
            displayImage.sprite = planetImage;
            displayImage.enabled = true;  // Make sure the image is visible
            Debug.Log("Planet image displayed.");
        }
        else
        {
            Debug.LogWarning("DisplayImage or PlanetImage is null in ShuttleDisplayController.");
        }
    }

    /// <summary>
    /// Clears and hides the planet image.
    /// </summary>
    public void ResetImage()
    {
        if (displayImage != null)
        {
            displayImage.sprite = null;
            displayImage.enabled = false;
            Debug.Log("🧹 Planet image cleared.");
        }
    }
}
