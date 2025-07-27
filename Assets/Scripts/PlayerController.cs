using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //rigidbody
    private bool isGravityNormal = true; //gravity normal
    private float moveSpeed = 2.0f; //speed
    private bool isGrounded = true; //isgrounded

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //import privately
        rb.linearVelocity = new Vector3(0, 0, moveSpeed); //start pushing the block from start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isGrounded) //if grounded and e is pressed
        {
            isGravityNormal = !isGravityNormal;
            Physics.gravity = isGravityNormal ? new Vector3(0, -9.81f, 0) : new Vector3(0, 9.81f, 0);

            isGrounded = false; //reset kar deta hai
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, moveSpeed); //constant phy
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}