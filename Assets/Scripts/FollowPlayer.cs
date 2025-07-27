using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;

    // Offset between camera and player
    public Vector3 offset = new Vector3(0, 5, -7);

    // Called after all Update() calls
    void LateUpdate()
    {
        // Set the camera's position relative to the player's position
        transform.position = player.transform.position + offset;
    }
}