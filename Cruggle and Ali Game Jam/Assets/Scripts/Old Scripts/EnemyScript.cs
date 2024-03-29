using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public bool goLeft;
    int direction = 1;
    public Transform groundDetection;
    public Transform wallDetection;
    bool isFacingRight = true;


    Rigidbody2D myRigidBody;
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    

    private void FixedUpdate()
    {

        Vector2 position = myRigidBody.position;

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
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;


        }

        myRigidBody.MovePosition(position);
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
