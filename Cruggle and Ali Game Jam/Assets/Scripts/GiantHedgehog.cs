using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHedgehog : MonoBehaviour
{
    public float speed;
    public bool goingLeft;
    int direction = 1;
    public Transform playerDetection;
    public Transform triggerDetection;
    public Transform nestTriggerDetection;
    bool isFacingRight = true;
    private RaycastHit2D playerInfo;
    public Animator animator;
    public bool isOverLedge;

    Vector2 position;




    Rigidbody2D myRigidbody;
    private void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }



    private void FixedUpdate()

    {

        RaycastHit2D nestTriggerInfo = Physics2D.Raycast(nestTriggerDetection.position, Vector2.left, 1f);
        if (nestTriggerInfo.collider == false || nestTriggerInfo.collider.tag != "NestTrigger")
        {


            playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.right * transform.localScale, 20f);

            if (playerInfo.collider == true && playerInfo.collider.tag == "Player")
            {
                animator.SetBool("CharacterTrigger", true);

                position.x = transform.localPosition.x;
            }
            else

            {
                animator.SetBool("CharacterTrigger", false);

                position = myRigidbody.position;


                RaycastHit2D triggerInfo = Physics2D.Raycast(triggerDetection.position, Vector2.down, 1f);
                if (triggerInfo.collider == true && triggerInfo.collider.tag == "HedgehogTrigger")
                {
                    Debug.Log("hit trigger");

                    goingLeft = true;
                    isOverLedge = true;

                    Vector3 theScale = transform.localScale;
                    theScale.x = -2;
                    transform.localScale = theScale;
                }

                if (goingLeft)
                {
                    position.x = position.x + Time.deltaTime * speed * -direction;

                }
                else if (goingLeft == false && isOverLedge == false)
                {
                    position.x = position.x + Time.deltaTime * speed * direction;

                }

                myRigidbody.MovePosition(position);
            }

            {
                animator.SetFloat("Speed", Mathf.Abs(speed));
            }


        }
        else

        {
            Debug.Log("nest trigger hit");
            position = myRigidbody.position;
            
            position.x = position.x + Time.deltaTime * 0 * direction;
            myRigidbody.MovePosition(position);

            animator.SetFloat("Speed", Mathf.Abs(0));

            animator.SetBool("HedgehogSleep", true);

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


}