using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHedgehogScript : MonoBehaviour
{
    public float speed;
    public bool goingLeft;
    int direction = 1;
    public Transform groundDetection;
    public Transform wallDetection;
    bool isFacingRight = true;
    private RaycastHit2D playerInfo;
    public Animator animator;

    Vector2 position;




    Rigidbody2D myRigidbody;
    private void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();

    }



    private void FixedUpdate()
    {
        if (goingLeft == true)
        {
            playerInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, 20f);

        }
        else
        {

            playerInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 20f);

        }

        if (playerInfo.collider == true && playerInfo.collider.tag == "Player")
        {
            animator.SetBool("CharacterTrigger", true);
            Debug.Log("hedgehog can sense the player");


            position.x = transform.localPosition.x;
        }
        else

        {
            animator.SetBool("CharacterTrigger", false);

            position = myRigidbody.position;

            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.1f);
            RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, 0.01f);
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


