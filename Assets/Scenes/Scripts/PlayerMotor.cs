using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f; //for falling player
    private float gravity = 12;
    private float jumpForce = 7.0f;

	// Use this for initialization
	void Start () { 
        //this tells playerMotor to use this controller the one in the player object
        controller = GetComponent<CharacterController>();  	}
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //x left and right  
        moveVector.x = Input.GetAxisRaw("Horizontal") * 4;

        //y up and down
        moveVector.y = verticalVelocity;

        //z forward and backward
        moveVector.z = speed;
        //tell it to move forward every frame at the time it takes to transition from frame to frame
        controller.Move((moveVector) * Time.deltaTime);  
        
	}
}
