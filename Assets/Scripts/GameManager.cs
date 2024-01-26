// GameManager.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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

    public float levelTimerDuration = 60f;
    private float levelTimer;

    public Text timerText;
    public int maxLives = 3;
    private int currentLives;
    public Text livesText;
    public Transform player;

    private Vector3 respawnPosition;

    private bool isGameOver = false;

    void Start()
    {
        levelTimer = levelTimerDuration;
        currentLives = maxLives;
        respawnPosition = player.position;

        UpdateUITimer();
        UpdateUILives();
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (levelTimer > 0)
            {
                levelTimer -= Time.deltaTime;
                UpdateUITimer();
            }
            else
            {
                if (currentLives > 0)
                {
                    currentLives--;
                    TriggerRespawn();
                }
                else
                {
                    GameOver();
                }
            }
        }
    }

    void UpdateUITimer()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.RoundToInt(levelTimer);
        }
    }

    void UpdateUILives()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    public void PlayerSteppedOnPressurePlate()
    {
        // Optionally, perform any actions or conditions related to the player stepping on the pressure plate.
        // Reset the respawn position to the player's current position.
        SetRespawnPosition(player.position);

        // Reset the level timer when the player steps on a pressure plate.
        ResetLevelTimer();

        Debug.Log("Player stepped on pressure plate.");
    }

    public void PlayerCrossedFinishLine()
    {
        // Handle victory condition here.
        if (!isGameOver)
        {
            isGameOver = true;
            SceneManager.LoadScene("VictoryScene");
        }
    }

    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }

    public void TriggerRespawn()
    {
        // Reset the level timer.
        levelTimer = levelTimerDuration;

        // Update UI elements.
        UpdateUITimer();
        UpdateUILives();

        // Teleport the player to the respawn position.
        player.position = respawnPosition;
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("GameOverScene");
    }

    public void ResetLevelTimer()
    {
        // Reset the level timer when the player steps on a pressure plate.
        levelTimer = levelTimerDuration;

        // Update UI elements.
        UpdateUITimer();
        UpdateUILives();
    }
}
