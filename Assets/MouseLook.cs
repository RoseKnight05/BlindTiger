using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2.0f;      // Sensitivity of the mouse movement
    public Transform playerBody;               // Reference to the player's body (this should be the player object)
    public float xRotation = 0.0f;             // Store vertical camera rotation (to prevent flipping)

    // You can adjust the speed of the camera rotation (horizontal and vertical)
    public float maxLookAngle = 90f;           // Maximum angle the camera can rotate vertically
    public float minLookAngle = -90f;          // Minimum angle the camera can rotate vertically

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input for both axes (Horizontal and Vertical)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Apply vertical rotation (camera rotation up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle); // Clamp vertical rotation to avoid flipping
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply horizontal rotation (player body rotation)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
