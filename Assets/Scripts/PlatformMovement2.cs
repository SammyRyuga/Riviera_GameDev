using UnityEngine;

public class PlatformMovement2 : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}