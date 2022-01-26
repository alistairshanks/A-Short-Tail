using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelScript2 : MonoBehaviour
{
    public float speed;
    public bool isGoingLeft;
    int direction = 1;
    public Transform groundDetection;
    public Transform wallDetection;
    bool isFacingRight = true;
    public Animator animator;
    public bool isRunning = false;

    public LayerMask ground;
    public LayerMask alsoGround;


   Rigidbody2D myRigidBody;



    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("SquirrelAnimations", 0f, 2.5f);

    }




    private void FixedUpdate()
    {
        // if it has been decided that the squirrel should be running
        if (isRunning == true)
        {
            {   //create a vector2 variable which stores the current position of the rigidbody on this gameobject
                Vector2 position = myRigidBody.position;

                {   //send out a ray from groundInfo and a ray from wallInfo, the rays will return true or false if they hit something

                    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.1f, ground);
                    RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right * transform.localScale, 0.01f, alsoGround);

                    // check if either there is no ground in front of the character (we are at the edge) or there is a wall
                    if (groundInfo.collider == false || wallInfo.collider == true)
                    {
                        //change whether we are going left or right by inversing the bool
                        isGoingLeft = !isGoingLeft;

                        //flip the local x scale which makes the sprite face the other way
                        Flip();
                    }

                    if (isGoingLeft)
                    {
                        // if we are going left, set the destination to the left and how long it takes to get there
                        position.x = position.x + Time.deltaTime * speed * -direction;

                    }
                    // else if we are going right
                    else
                    {   // set the destination to the right and how long it takes to get there
                        position.x = position.x + Time.deltaTime * speed * direction;


                    }
                }
                //ask the rigidbody to move to the destination
                myRigidBody.MovePosition(position);

            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void SquirrelAnimations()
    {
        //generate some random values
        float myRandomNumber = Random.value;
        float idleRandomNumber = Random.value;

        //check if the random value is within a certain range to decide whether we want to run or be idle
        if (myRandomNumber < 0.60)
        {
            //turn on the movement part of the script and turn off all other animations
            isRunning = true;
            animator.SetFloat("Speed", (speed));
            animator.SetBool("Dig", false);
            animator.SetBool("Nut", false);

        }

        //check which idle animation we want  to happen
        else if (myRandomNumber >= 0.61)

        {
            //turn off the movement part off the script and set the animation speed to 0, which switches it off
            isRunning = false;
            animator.SetFloat("Speed", (0));

            //check if random number falls in a certain range, if it does, turn on dig animation
            if (idleRandomNumber < 0.7)
            {
                animator.SetBool("Dig", true);
                animator.SetBool("Nut", false);
            }

            //if it falls in this range then turn on dig animation and after 1 second invoke "SquirrelFindsNut"
            else if (idleRandomNumber > 0.7)

            {
                animator.SetBool("Dig", true);
                animator.SetBool("Nut", false);
                Invoke("SquirrelFindsNut", 1f);

            }
        }
    }       

    // a simple function to call from invoke which turns on nut animation and turns off dig animation
    void SquirrelFindsNut()
    {
        animator.SetBool("Dig", false);
        animator.SetBool("Nut", true);

    }
}
