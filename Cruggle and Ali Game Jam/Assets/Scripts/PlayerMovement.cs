using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // declare a variable to contain character controller script
    public CharacterController2D controller;
    //declare a variable to contain how much we want to move
    float horizontalMove = 0f;
    //declare a variable for the speed of movement
    public float runSpeed = 40f;
    //declare a variable to contain whether character is jumping or not
    bool jump = false;

    void Update()
    {
        // detect whether player is pushing "a" key or "d" key to see if they want to go left or right
        horizontalMove =Input.GetAxisRaw("Horizontal") * runSpeed;

        // if spacebar is pushed player, then make jump true
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        /* tell our controller script to move the player and tell it whether we are jumping and whether
         we are crouched */
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
