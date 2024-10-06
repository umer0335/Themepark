using UnityEngine;
using UnityEngine.UI;

public class SpinningCup : MonoBehaviour
{
    public float spinSpeed = 1f;    // Speed of the spinning motion

    
    //private bool isSpinning = true;   // The ride should spin by default
    private bool isPaused = false;    // Controls if the ride is explicitly paused/stopped by user
    public RideUIController rideUIController;

    void Start()
    {

        // Start with the main camera enabled
        CameraSwitcher.Instance.SwitchToDefaultCamera();
    }

    void Update()
    {
        if (!isPaused)  // Spin the ride only if it's not paused
        {
            PerformSpinning();

        }
    }
    // Method to handle the spinning motion
    private void PerformSpinning()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime * 100, 0);
    }

    // Call this when the user selects the ride
    public void SelectRide()
    {
        isPaused = false;

        // Switch to the spinning cup camera
        CameraSwitcher.Instance.SwitchToCupCamera();
    }

    // Call this when the user deselects the ride
    public void DeselectRide()
    {
        isPaused = false;

        // Switch back to the default camera
        CameraSwitcher.Instance.SwitchToDefaultCamera();
    }

    // Method to adjust the spinning speed from the UI slider
    public void SetSpeed(float newSpeed)
    {
        spinSpeed = newSpeed;  // Update the spinning speed
    }

    // Handle interaction, e.g., clicking on the ride
    private void OnMouseDown()
    {
        // When the ride is clicked, notify the UI controller
        if (rideUIController != null)
        {
            rideUIController.RideSelected(this);
        }
    }

    
}
