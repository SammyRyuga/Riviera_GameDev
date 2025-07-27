using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 0, 90); // Snap rotate CCW on Z-axis
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 0, -90); // Snap rotate CW on Z-axis
        }
    }
}