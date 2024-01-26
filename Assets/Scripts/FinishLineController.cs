// FinishLineController.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify GameManager that the player crossed the finish line.
            GameManager.Instance.PlayerCrossedFinishLine();
        }
    }
}
