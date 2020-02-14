using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // This is a reference to the Rigidbody component called 'rb'
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Observer pattern variables
    public delegate void ReachCheckpoint();
    public delegate void Failure();
    public static event ReachCheckpoint OnReachHalfway;
    public static event ReachCheckpoint OnPastHalfway;
    public static event Failure OnFall;

    Vector3 startPos;
    public GameObject goal;
    Vector3 goalPos;
    Vector3 halfwayPos;

    // Get z halfway point
    public void Start()
    {
        startPos = rb.transform.position;
        goalPos = goal.transform.position;
        halfwayPos = (goalPos - startPos) / 2;
    }

    // We marked this as "Fixed"Update because we
    // are using it to mess with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))     // If the player is perssing the "d" key
        {
            // Add a force to the right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))      // If the player is pressing the "a" key
        {
            // Add a force to the left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            if (OnFall != null)
            {
                OnFall();
            }
        }

        if (rb.position.z >= halfwayPos.z)
        {
            if (OnReachHalfway != null)
            {
                OnReachHalfway();
            }
        }

        if (rb.position.z >= halfwayPos.z + 100)
        {
            if (OnPastHalfway != null)
            {
                OnPastHalfway();
            }
        }
    }
}