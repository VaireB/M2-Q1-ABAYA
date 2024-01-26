// MainMenuManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene. Make sure your game scene is added to the build settings.
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        // Quit the application (works in standalone builds).
        Application.Quit();
    }
}
