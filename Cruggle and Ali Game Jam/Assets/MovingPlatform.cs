using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask myLayerMask;
    private bool goingLeft;
    public Rigidbody2D myRigidbody;
    int direction = 1;
    Vector2 position;
    public bool isFacingRight = true;
    


    public Transform wallDetection;


    private void FixedUpdate()
    {


        position = myRigidbody.position;

        
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right * transform.localScale, 0.01f, ~myLayerMask);
        if ( wallInfo.collider == true && wallInfo.collider.tag != "Player")
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

    

