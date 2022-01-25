using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bounce = 20f;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

            animator.SetBool("static", false);
            animator.SetBool("jump", true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("jump", false);
        animator.SetBool("static", true);
    }
}
