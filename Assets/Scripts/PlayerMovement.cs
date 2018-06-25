using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    public float speed = .36f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)&& player.transform.position.z <= 74.5)
        {
            player.transform.position += Vector3.forward * speed;
        }
        else if(Input.GetKey(KeyCode.S) && player.transform.position.z >=-69.5)
        {
            player.transform.position -= Vector3.forward * speed;

        }
    }
}
