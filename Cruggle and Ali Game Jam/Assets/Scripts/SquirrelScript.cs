using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelScript : MonoBehaviour
{
    public float speed;
    public bool goLeft;
    int direction = 1;
    public Transform groundDetection;
    public Transform wallDetection;
    bool isFacingRight = true;
    public Animator animator;
    public float TimeRemaining = 5;
    public bool IsRunning = false;


   Rigidbody2D myRigidBody;



    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("SquirrelAnimations", 1.0f, 2f);

    }




    private void FixedUpdate()
    {

        if (IsRunning == true)
        {

            {

                Vector2 position = myRigidBody.position;

                {


                    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.1f);
                    RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 0.01f);
                    if (groundInfo.collider == false || wallInfo.collider == true)
                    {
                        goLeft = !goLeft;

                        Flip();
                    }

                    if (goLeft)
                    {
                        position.x = position.x + Time.deltaTime * speed * -direction;
                        animator.SetFloat("Speed", (speed));
                    }
                    else
                    {
                        position.x = position.x + Time.deltaTime * speed * direction;
                        animator.SetFloat("Speed", (speed));

                    }
                }

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
        float myRandomNumber = Random.value;

        float IdleRandomNumber = Random.value;

        if (myRandomNumber < 0.60)
        {
            IsRunning = true;
            animator.SetBool("Dig", false);
            animator.SetBool("Nut", false);
            
        }

        else if (myRandomNumber > 0.61)

        {
            IsRunning = false;
            

            if (IdleRandomNumber <= 0.5)
            {
                animator.SetBool("Dig", true);
                animator.SetBool("Nut", false);
                
                
            }

            else if (IdleRandomNumber <= 0.5)
            {
                animator.SetBool("Nut", true);
                animator.SetBool("Dig", false);
                
                
            }
        }
    }       
}
