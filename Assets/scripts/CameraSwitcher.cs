using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera defaultCamera; 
    public Camera cupCamera;
    public Camera gallopingCamera;
    public Camera wildRideCamera;

    private Camera currentCamera;

    // Singleton instance for global access
    public static CameraSwitcher Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // Ensures only one instance exists
        }
    }

    void Start()
    {
        SwitchToDefaultCamera();
    }

    public void SwitchToDefaultCamera()
    {
        DisableAllCameras();
        defaultCamera.enabled = true;
        currentCamera = defaultCamera;
    }

    public void SwitchToCupCamera()
    {
        DisableAllCameras();
        cupCamera.enabled = true;
        currentCamera = cupCamera;
    }

    public void SwitchToGallopingCamera()
    {
        DisableAllCameras();
        gallopingCamera.enabled = true;
        currentCamera = gallopingCamera;
    }

    public void SwitchToWildRideCamera()
    {
        DisableAllCameras();
        wildRideCamera.enabled = true;
        currentCamera = wildRideCamera;
    }

    void DisableAllCameras()
    {
        defaultCamera.enabled = false;
        cupCamera.enabled = false;
        gallopingCamera.enabled = false;
        wildRideCamera.enabled = false;
    }

    public void SwitchToChildCamera(Camera childCamera)
    {
        if (currentCamera != childCamera)
        {
            DisableAllCameras();
            childCamera.enabled = true;
            currentCamera = childCamera;
        }
        else
        {
            SwitchToDefaultCamera();
        }
    }
}
