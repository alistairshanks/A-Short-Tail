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
    public bool appleTrigger;
    public bool hedgehogIsAsleep = false;
    private BoxCollider2D myBoxCollider2D;
    public GameObject thoughtBubble;
    bool isSpiked = false;
    public GameObject hedgeHogWall;

    float damageBounce = 10f;

    Vector2 position;




    Rigidbody2D myRigidbody;
    private void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && hedgehogIsAsleep == false)
        {
            isSpiked = true;
            animator.SetBool("CharacterTrigger", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isSpiked = false;
            animator.SetBool("CharacterTrigger", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSpiked && collision.gameObject.CompareTag("Player"))
        {
            CharacterController2D.instance.ChangeHealth(-33);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * damageBounce, ForceMode2D.Impulse);
        }
    }



    private void FixedUpdate()

    { if (appleTrigger == true)
        {

            hedgeHogWall.SetActive(false);
            thoughtBubble.SetActive(true);

            Invoke("CancelThoughtBubble", 1f);

            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().drag = 0;
            GetComponent<Rigidbody2D>().gravityScale = 100;

            myBoxCollider2D = GetComponent<BoxCollider2D>();
            myBoxCollider2D.enabled = false;

            RaycastHit2D nestTriggerInfo = Physics2D.Raycast(nestTriggerDetection.position, Vector2.right, 1f);
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

                        Vector3 theScale = transform.localScale;
                        theScale.x = 2;
                        transform.localScale = theScale;

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
                GetComponent<Rigidbody2D>().isKinematic = true;

                appleTrigger = false;
                hedgehogIsAsleep = true;
                

            }



        }

        

    }

    void GoToNest()
    {
        

            myBoxCollider2D = GetComponent<BoxCollider2D>();
            myBoxCollider2D.enabled = false;

            RaycastHit2D nestTriggerInfo = Physics2D.Raycast(nestTriggerDetection.position, Vector2.right, 1f);
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

                        Vector3 theScale = transform.localScale;
                        theScale.x = 2;
                        transform.localScale = theScale;

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

                appleTrigger = false;
                hedgehogIsAsleep = true;
                GetComponent<Rigidbody2D>().drag = 1000;

            }
        

    }

    void CancelThoughtBubble()
    {
        thoughtBubble.SetActive(false);
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