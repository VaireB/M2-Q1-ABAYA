// GameManager.cs (GameOverScene)
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name;
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

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
