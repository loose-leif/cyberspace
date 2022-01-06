using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing
public class PlayerMovement : MonoBehaviour
{

    //initalizes player controller
    public CharacterController controller;

    //player's properties
    public float movespeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //allows to check for ground so gravity doesn't push them through the ground.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //checks whether or not player is grounded.. if not do not let them jump!
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if they are grounded and their y velocity is greater than 0 set velocity y to 0.
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        //inputers
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //what direction the player wants to move.
        Vector3 move = transform.right * x + transform.forward * z;

        //checks whether the player is jumping or not. If they are not grounded will not allow them to jump.
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //when the controller wants to move.
        controller.Move(move * movespeed * Time.deltaTime);

        //gravity enforces the player falls.
        velocity.y += gravity * Time.deltaTime;
    }
}
