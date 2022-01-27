using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogScript : MonoBehaviour
{
    public float speed;
    public bool goingLeft;
    int direction = 1;
    public Transform groundDetection;
    public Transform wallDetection;
    bool isFacingRight = true;
    private RaycastHit2D playerInfo;
    public Animator animator;
    public LayerMask myLayerMask;
    bool isFalling = false;
    bool isDead = false;
    public GameObject wholeHedgehog;
    private float damageBounce = 10f;


    public bool isSpiked;

    Vector2 position;




    Rigidbody2D myRigidbody;
    private void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSpiked && collision.gameObject.CompareTag("Player"))
        {
            CharacterController2D.instance.ChangeHealth(-33);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * damageBounce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSpiked && collision.tag == "Player")
        {
            CharacterController2D.instance.ChangeHealth(-33);

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * damageBounce, ForceMode2D.Impulse);
        }

        else if (!isSpiked && collision.tag == "Player")
        {
            isDead = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFalling != true && isDead != true)
        {
            playerInfo = Physics2D.Raycast(wallDetection.position, Vector2.right * transform.localScale, 7.5f, ~myLayerMask);

            if (playerInfo.collider == true && playerInfo.collider.tag == "Player")
            {
                animator.SetBool("CharacterTrigger", true);

                isSpiked = true;

                position.x = transform.localPosition.x;
            }
            else

            {
                if (isSpiked == false)
                {
                    animator.SetBool("CharacterTrigger", false);

                    position = myRigidbody.position;

                    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.1f, ~myLayerMask);
                    RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right * transform.localScale, 0.01f, ~myLayerMask);
                    if (groundInfo.collider == false || wallInfo.collider == true && playerInfo.collider.tag != "Player")
                    {
                        goingLeft = !goingLeft;

                        Flip();
                    }

                    if (goingLeft)
                    {
                        position.x = position.x + Time.deltaTime * speed * -direction;

                    }
                    else
                    {
                        position.x = position.x + Time.deltaTime * speed * direction;

                    }

                    myRigidbody.MovePosition(position);
                }

                {
                    animator.SetFloat("Speed", Mathf.Abs(speed));
                }
            }
        }

        if (isDead == true)
        {
            GetComponent<Rigidbody2D>().drag = 0;
            HedgehogDead();

            if (transform.position.y <= -30f)
            {
                Destroy(wholeHedgehog);
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

    void HedgehogDead()
    {
        isFalling = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
       
        
    }


}

