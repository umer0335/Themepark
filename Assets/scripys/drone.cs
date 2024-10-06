using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float moveSpeed = 10.0f;  // Speed of drone movement
    public float rotationSpeed = 100.0f;  // Speed of drone rotation
    public Camera droneCamera;  // Camera attached to the drone
    public Camera mainCamera;  // Main camera (when drone mode is inactive)

    public GameObject droneControlPanel;  // Optional control panel (can be hidden in drone mode)

    private bool isDroneModeActive = false;

    private void Start()
    {
        // Start with main camera active and drone camera inactive
        mainCamera.enabled = true;
        droneCamera.enabled = false;

        if (droneControlPanel != null)
        {
            droneControlPanel.SetActive(false);  // Hide the control panel initially
        }
    }

    private void Update()
    {
        // Listen for the key press to toggle drone mode (using 'T' as an example)
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleDroneMode();
        }

        if (isDroneModeActive)
        {
            ControlDrone();
        }
    }

    // Method to toggle drone mode on and off
    private void ToggleDroneMode()
    {
        isDroneModeActive = !isDroneModeActive;

        if (isDroneModeActive)
        {
            // Switch to the drone camera
            mainCamera.enabled = false;
            droneCamera.enabled = true;

            if (droneControlPanel != null)
            {
                droneControlPanel.SetActive(true);  // Show the control panel
            }
        }
        else
        {
            // Switch back to the main camera
            mainCamera.enabled = true;
            droneCamera.enabled = false;

            if (droneControlPanel != null)
            {
                droneControlPanel.SetActive(false);  // Hide the control panel
            }
        }
    }

    // Method to control the drone movement
    private void ControlDrone()
    {
        // Get input for movement and rotation
        float moveDirection = Input.GetAxis("Vertical");  // Forward/Backward (W/S)
        float rotationDirection = Input.GetAxis("Horizontal");  // Left/Right rotation (A/D)

        // Move the drone forward/backward
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the drone around the Y-axis (yaw)
        transform.Rotate(Vector3.up * rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
