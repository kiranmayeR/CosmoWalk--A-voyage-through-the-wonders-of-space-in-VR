using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be triggered by the button
    public void StartNavigation()
    {
        // Replace this with your actual scene name
        SceneManager.LoadScene("solartour");
    }
}