using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;  // Required for XR interactions

public class BigRedButtonSceneLoader : MonoBehaviour
{
    // This method will be called when the button is poked
    public void OnButtonPoked()
    {
        // Load the "Marsenv" scene
        //SceneManager.LoadScene("Marsenv");
        SceneManager.LoadScene("Marsenv");
        Debug.Log("Button Poked! Loading Marsenv scene...");
    }
}