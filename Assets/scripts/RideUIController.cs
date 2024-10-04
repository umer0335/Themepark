using UnityEngine;
using UnityEngine.UI;

public class RideUIController : MonoBehaviour
{
    // Public references to the start and stop buttons
    public Button startButton;
    public Button stopButton;

    // A reference to the currently selected ride (can be any ride)
    private MonoBehaviour currentRide;

    void Start()
    {
        // Ensure buttons are assigned and disable them at the start
        if (startButton != null) startButton.gameObject.SetActive(false);
        if (stopButton != null) stopButton.gameObject.SetActive(false);

        // Add listeners for the buttons
        startButton.onClick.AddListener(StartRide);
        stopButton.onClick.AddListener(StopRide);
    }

    // Method to be called when a ride is selected to activate the UI
    public void RideSelected(MonoBehaviour ride)
    {
        currentRide = ride;

        // Enable the UI buttons for controlling the selected ride
        startButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(true);
    }

    // Method to start the selected ride
    public void StartRide()
    {
        if (currentRide != null)
        {
            if (currentRide is GallopingRide gallopingRide)
            {
                gallopingRide.SelectRide();
            }
            else if (currentRide is SpinningCup spinningCup)
            {
                spinningCup.SelectRide();
            }
            else if (currentRide is WildRide wildRide)
            {
                wildRide.SelectRide();
            }
        }
    }

    // Method to stop the selected ride
    public void StopRide()
    {
        if (currentRide != null)
        {
            if (currentRide is GallopingRide gallopingRide)
            {
                gallopingRide.DeselectRide();
            }
            else if (currentRide is SpinningCup spinningCup)
            {
                spinningCup.DeselectRide();
            }
            else if (currentRide is WildRide wildRide)
            {
                wildRide.DeselectRide();
            }

            // Optionally disable the buttons when the ride is stopped
            startButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(false);
        }
    }
}
