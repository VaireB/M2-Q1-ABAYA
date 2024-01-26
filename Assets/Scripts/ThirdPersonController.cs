using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Camera Settings")]
    [SerializeField] private float cameraHeightOffset = 2f;
    [SerializeField] private float cameraBackwardOffset = 5f;
    [SerializeField] private float cameraLerpSpeed = 5f;

    private bool isGrounded;
    private Rigidbody rb;
    private Camera playerCamera;
    private Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        cameraTransform = playerCamera.transform;
    }

    void Update()
    {
        Move();
        RotateWithMouse();
        Jump();
        UpdateCameraFollow();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0f;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void UpdateCameraFollow()
    {
        Vector3 targetPosition = transform.position + (Vector3.up * cameraHeightOffset) - (transform.forward * cameraBackwardOffset);
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, targetPosition, Time.deltaTime * cameraLerpSpeed);
        playerCamera.transform.LookAt(transform.position + Vector3.up);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
