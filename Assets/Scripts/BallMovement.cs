using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    // Use this for initialization
    public GameObject ball;
    public float speed = 3.2f;
    bool collided = false;
    public Vector3 velocity;
    public float HitOffset = 35f;
	void Start () {
        ball.transform.position = new Vector3(97, 3, 1);
        velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        float radiants = 0;
        while (radiants == 0)
        {
            radiants = Random.Range(0, 2 * Mathf.PI);
        }
        velocity = new Vector3(Mathf.Cos(radiants), 0,Mathf.Sin(radiants));
        velocity.Normalize();
        velocity *= speed;
        ball.GetComponent<Rigidbody>().AddForce(velocity);
    }

    // Update is called once per frame
    void Update () {
        //  velocity.Normalize();
        HitOffset = Random.Range(60, 120);
        ball.GetComponent<Rigidbody>().velocity =(velocity* HitOffset * Time.deltaTime);

    }
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the side walls inn that case move towards a random position
        if (collision.gameObject.tag == "SideWall")
        {

            velocity = new Vector3(velocity.x, 0, -velocity.z);
           // velocity.Normalize();
            ball.GetComponent<Rigidbody>(). velocity= (velocity * speed * Time.deltaTime * HitOffset);
            //  ball.GetComponent<Rigidbody>().AddForce(velocity * speed);
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Touched side wall");
        }

        //Check for a match with the wall behind each players paddle 
        if (collision.gameObject.tag == "behindPaddle")
        {
            Start();
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("respwaning ");
        }
        else if(collision.gameObject.tag == "Player1Paddle")
        {
            velocity = new Vector3(-velocity.x, 0, -velocity.z);
           // velocity.Normalize();
            ball.GetComponent<Rigidbody>().velocity=(velocity * speed * Time.deltaTime* HitOffset);
        }
        else if (collision.gameObject.tag == "AI")
        {
            velocity = new Vector3(-velocity.x, 0, -velocity.z);
            //velocity.Normalize();
            ball.GetComponent<Rigidbody>().velocity = (velocity * speed*Time.deltaTime * HitOffset);
        }
    }
    public float normalizeAngle(int angle)
    {
        int newAngle = angle;
        while (newAngle <= -180) newAngle += 360;
        while (newAngle > 180) newAngle -= 360;
        return newAngle;
    }

}
