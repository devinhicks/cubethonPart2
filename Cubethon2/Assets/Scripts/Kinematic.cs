using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    // position comes from attached gameobject transform
    // rotation as well
    public Vector3 linearVelocity;
    public float speedMultiplier = 1f;
    public float angularVelocity; // degrees please
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // update position and rotation
        transform.position += linearVelocity * Time.deltaTime;
        Vector3 angularIncrement = new Vector3(0, angularVelocity * Time.deltaTime, 0);
        transform.eulerAngles += angularIncrement;

        // update linear and angular velocity
        Seek mySeek = new Seek();
        mySeek.character = this;
        mySeek.target = target;
        SteeringOutput steering = mySeek.getSteering();
        linearVelocity += steering.linear * speedMultiplier * Time.deltaTime;
        angularVelocity += steering.angular * Time.deltaTime;
    }
}
