using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    // Rotation speed, adjustable from the Inspector
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the platform around the Y-axis (up axis) at a constant speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
