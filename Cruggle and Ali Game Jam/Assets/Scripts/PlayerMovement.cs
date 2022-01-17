using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    float horizontalMove = 0f;

    public float runSpeed = 40f;
    bool jump = false;


    private void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));




        if (Input.GetButtonDown("Jump"))

        {
            jump = true;
            animator.SetBool("IsJumping", true);

        }

        if (timerIsRunning)
        {


            if (timeRemaining > 0)

            {
                timeRemaining -= Time.deltaTime;
            }

            






            else
            {
                Debug.Log("time has run out");

                timeRemaining = 0;

                timerIsRunning = false;

                animator.SetBool("TimePassedSleep", true);
                animator.SetBool("TimePassed", false); 

            }

     

        }

        if(timerIsRunning)

        {
            if (timeRemaining < 7)
            {
                animator.SetBool("TimePassed", true);
            }


        }

        

        
           

        if (horizontalMove > 0.0f)

        {
            timeRemaining = 10;
            timerIsRunning = true;
            animator.SetBool("TimePassedSleep", false);
            animator.SetBool("TimePassed", false);
        }

        
            

        
    }

        public void Onlanding()

        {
            animator.SetBool("IsJumping", false);
        }


        private void FixedUpdate()
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;

        }



 }


