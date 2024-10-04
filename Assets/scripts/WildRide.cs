using UnityEngine;
using UnityEngine.UI;

public class WildRide : MonoBehaviour
{
    // Ride parameters
    public float maxHeight = 100.0f;      // Maximum height the duck will go up to
    public float riseSpeed = 50.0f;       // Speed at which the duck rises
    public float fallSpeed = 100.0f;      // Speed at which the duck falls back down
    public float platformHeight = 0.0f;   // Y position of the platform (ground level)
    public float initialHeight = 50.0f;   // Initial height from which the duck starts

    private bool goingUp = true;          // Track if the duck is going up or down
    private bool isBouncing = true;       // The ride should bounce by default
    private bool isPaused = false;        // Controls if the ride is explicitly paused/stopped by user
    private float currentHeight;          // Track the current height of the duck

    // Reference to the UI controller
    public RideUIController rideUIController;
    void Start()
    {
        // Set the duck's initial position to start above the platform
        currentHeight = platformHeight + initialHeight;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

    

        // Start with the main camera enabled
        CameraSwitcher.Instance.SwitchToDefaultCamera();
    }

    void Update()
    {
        if (!isPaused)
        {
            WildRideEffect();  // Continuously perform the bouncing effect
        }
    }

    // Method to control the wild ride's bouncing effect
    private void WildRideEffect()
    {
        // If the duck is going up
        if (goingUp)
        {
            // Move the duck up by the rise speed
            currentHeight += riseSpeed * Time.deltaTime;

            // If the duck reaches the max height, reverse direction (start falling)
            if (currentHeight >= maxHeight)
            {
                currentHeight = maxHeight;  // Clamp to max height
                goingUp = false;            // Start going down
            }
        }
        // If the duck is going down
        else
        {
            // Move the duck down by the fall speed
            currentHeight -= fallSpeed * Time.deltaTime;

            // If the duck reaches the platform, reverse direction (start going up)
            if (currentHeight <= platformHeight)
            {
                currentHeight = platformHeight;  // Clamp to platform height
                goingUp = true;                  // Start going up again
            }
        }

        // Apply the new Y position to the duck, keeping X and Z unchanged
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }
    // Call this when the user selects the ride
    public void SelectRide()
    {
        isPaused = false;

        // Switch to Wild Ride Camera
        CameraSwitcher.Instance.SwitchToWildRideCamera();
    }

    // Call this when the user deselects the ride
    public void DeselectRide()
    {
        isPaused = false;
        Debug.Log("Ride paused");

        // Switch back to Default Camera
        CameraSwitcher.Instance.SwitchToDefaultCamera();
    }

    // Handle interaction, e.g., clicking on the ride
    private void OnMouseDown()
    {
        // When the ride is clicked, notify the UI controller
        if (rideUIController != null)
        {
            rideUIController.RideSelected(this);  // Pass this ride to the UI controller
        }
    }
    

    
}