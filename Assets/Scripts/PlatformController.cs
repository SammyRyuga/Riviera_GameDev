using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool isRotating = false;
    private Vector3 lastWallNormal = Vector3.up;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            RotateAndStick(-90f, Vector3.forward); //counterclockwise 90 degrees around Z-axis
        }
        if (Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            RotateAndStick(90f, Vector3.forward); //clockwise 90 degrees around Z-axis
        }
    }

    void RotateAndStick(float angle, Vector3 axis)
    {
        isRotating = true;
        transform.Rotate(axis, angle, Space.Self); //rotate the axis
        AlignToWall();
        Invoke("ResetRotationFlag", 0.1f); //a delay to stop spam rotations
    }

    void AlignToWall()
    {
        //determine the nearest wall based on the current rotation
        Vector3 forward = transform.forward;
        Vector3 up = transform.up;
        float dotForward = Mathf.Abs(Vector3.Dot(forward, Vector3.right));
        float dotUp = Mathf.Abs(Vector3.Dot(up, Vector3.up));

        if (dotForward > dotUp)
        {
            //align to side wall
            if (forward.x > 0) lastWallNormal = -Vector3.right; // Right wall
            else lastWallNormal = Vector3.right; // Left wall
        }
        else
        {
            //align to top or bottom wall
            if (up.y > 0) lastWallNormal = Vector3.up; // Top wall
            else lastWallNormal = Vector3.down; // Bottom wall
        }

        //stick cubes to the wall by adjusting their position
        Vector3 offset = -lastWallNormal * 0.5f; //adjusts based on cube size
        transform.position += offset;
    }

    void ResetRotationFlag()
    {
        isRotating = false;
    }
}