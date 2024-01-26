// PressurePlateController.cs
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public GameObject door;
    public Material defaultMaterial;
    public Material activatedMaterial;

    public Transform respawnPoint; // Assign the respawn point in the inspector.

    private bool isActivated = false;
    private Renderer plateRenderer;

    void Start()
    {
        plateRenderer = GetComponent<Renderer>();
        plateRenderer.material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            plateRenderer.material = activatedMaterial;
            Destroy(door);

            // Notify GameManager that the player stepped on the pressure plate.
            GameManager.Instance.PlayerSteppedOnPressurePlate();

            // Set the respawn position to the specified coordinates.
            SetRespawnPosition();

            isActivated = true;
        }
    }

    private void SetRespawnPosition()
    {
        // Set the respawn position to the assigned respawn point.
        if (respawnPoint != null)
        {
            GameManager.Instance.SetRespawnPosition(respawnPoint.position);
        }
    }
}
