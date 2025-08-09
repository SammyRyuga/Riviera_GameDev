using UnityEngine;

public class CollisionReset : MonoBehaviour
{
    public GameObject player;                     
    public Vector3 resetPosition = new Vector3(0, 1, 0);  //reset 

    private void OnTriggerEnter(Collider other)
    {
        //check if object has the tag "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Hit obstacle. Resetting player...");

            //move player to reset position
            player.transform.position = resetPosition;

            //reset rb velocity
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;            
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}