using UnityEngine;
using UnityEngine.UI;

public class RideUIController : MonoBehaviour
{
    // Public references to the start and stop buttons
    public Button startButton;
    public Button stopButton;
    public Slider speedSlider;
    
    private float defaultSliderValue = 0.5f;  // Declare it here at the class level
    // Minimum and maximum allowed speed values
    private float minSpeed = 0.5f;
    private float maxSpeed = 50.0f;

    // A reference to the currently selected ride (can be any ride)
    private MonoBehaviour currentRide;

    void Start()
    {
        // Ensure buttons are assigned and disable them at the start
        if (startButton != null) startButton.gameObject.SetActive(false);
        if (stopButton != null) stopButton.gameObject.SetActive(false);
        if (speedSlider != null)
        {
            speedSlider.gameObject.SetActive(false); // Hide the slider initially
            speedSlider.minValue = minSpeed;  // Set the minimum value for the slider
            speedSlider.maxValue = maxSpeed;  // Set the maximum value for the slider
        }
        // Add listeners for the buttons
        startButton.onClick.AddListener(StartRide);
        stopButton.onClick.AddListener(StopRide);
        speedSlider.onValueChanged.AddListener(AdjustRideSpeed); // Listen for slider value changes

    }

    // Method to be called when a ride is selected to activate the UI
    public void RideSelected(MonoBehaviour ride)
    {
        currentRide = ride;
        // Reset the slider value to default
        if (speedSlider != null)
        {
            speedSlider.value = defaultSliderValue;  // Reset the slider to the default value
        }

        // Enable the UI buttons for controlling the selected ride
        startButton.gameObject.SetActive(true);
        stopButton.gameObject.SetActive(true);
        speedSlider.gameObject.SetActive(true); // Show the slider

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
            speedSlider.gameObject.SetActive(false); // Hide the slider

        }
    }
    // Method to adjust the ride speed based on the slider value
    public void AdjustRideSpeed(float speed)
    {
        if (currentRide != null)
        {
            if (currentRide is GallopingRide gallopingRide)
            {
                gallopingRide.SetSpeed(speed); // Assuming GallopingRide has a SetSpeed method
            }
            else if (currentRide is SpinningCup spinningCup)
            {
                spinningCup.SetSpeed(speed); // Assuming SpinningCup has a SetSpeed method
            }
            else if (currentRide is WildRide wildRide)
            {
                wildRide.SetSpeed(speed); // Assuming WildRide has a SetSpeed method
            }
        }
    }
}