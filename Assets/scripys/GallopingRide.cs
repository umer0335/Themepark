using UnityEngine;
using UnityEngine.UI;

public class GallopingRide : MonoBehaviour
{
    public RideUIController rideUIController;  // Reference to the UI controller

    public float gallopSpeed = 2f;   // Speed of the galloping motion
    public float gallopHeight = 0.5f; // Height of the gallop movement




    private Vector3 originalPosition;  // The original position of the object
    private bool isGalloping = true;  // Ride should move by default
    private bool isPaused = false;    // Controls if the ride is explicitly paused/stopped by user

    void Start()
    {
        originalPosition = transform.localPosition;

        // Start with the main camera enabled
        CameraSwitcher.Instance.SwitchToDefaultCamera();
    }

    void Update()
    {
        if (!isPaused)  // Move the ride only if it's not paused
        {
            PerformGalloping();
        }

    }
     // Method to control the galloping motion
    void PerformGalloping()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * gallopSpeed) * gallopHeight;
        transform.localPosition = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

     // Call this when the user selects the ride
    public void SelectRide()
    {
        isPaused = false;
        isGalloping = true;

        // Switch to the galloping camera
        CameraSwitcher.Instance.SwitchToGallopingCamera();
    }
    // Call this when the user deselects the ride
    public void DeselectRide()
    {
        isPaused = false;
        isGalloping = true;

        // Switch back to the default camera
        CameraSwitcher.Instance.SwitchToDefaultCamera();
    }
    // Method to adjust the gallop speed from the UI slider
    public void SetSpeed(float newSpeed)
    {
        gallopSpeed = newSpeed;  // Set the new speed value based on the slider input
    }
  
    // Method to handle interaction, e.g., raycast hits or collision triggers
    private void OnMouseDown()
    {
        // When the ride is clicked, notify the UI controller
        if (rideUIController != null)
        {
            rideUIController.RideSelected(this);
        }
    }

    
    
}
