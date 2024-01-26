// VictorySceneManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorySceneManager : MonoBehaviour
{
    public void Retry()
    {
        // Reload the GameScene.
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        // Load the main menu scene.
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        // Quit the application (works in standalone builds).
        Application.Quit();
    }
}
