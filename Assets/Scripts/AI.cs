using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public GameObject AIPlayer;
    Rigidbody AIRigidBody;
    public GameObject Ball;
    public float Distance=0;
    public float speed = 4.5f;
	// Use this for initialization
	void Start () {
        AIRigidBody = AIPlayer.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Distance = Vector3.Distance(AIPlayer.transform.position, Ball.transform.position);
        Debug.Log(Distance);
        if (Distance <= 100f)
        {
           if(Ball.transform.position.z>0 && AIPlayer.transform.position.z <= 74.5)
            {
                AIPlayer.transform.position += Vector3.forward*Time.deltaTime*speed;
            }
            else if(Ball.transform.position.z < 0&& AIPlayer.transform.position.z >= -69.5)
            {
                AIPlayer.transform.position -= Vector3.forward*Time.deltaTime*speed;

            }
        }
	}
}
