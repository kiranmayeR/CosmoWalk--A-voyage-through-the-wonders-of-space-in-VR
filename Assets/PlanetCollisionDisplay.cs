using UnityEngine;
using UnityEngine.UI;

public class PlanetCollisionDisplay : MonoBehaviour
{
    public Image shuttleDisplayImage; // Drag your shuttle's UI Image here

    [System.Serializable]
    public class PlanetData
    {
        public string planetName;       // e.g., "Mars", "Earth"
        public Sprite planetSprite;     // Image to display
    }

    public PlanetData[] planets; // List of all planets and their images

    private void OnCollisionEnter(Collision collision)
    {
        foreach (PlanetData planet in planets)
        {
            if (collision.gameObject.name.Contains(planet.planetName))
            {
                shuttleDisplayImage.sprite = planet.planetSprite;
                return;
            }
        }
    }
}