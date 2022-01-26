using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bounce = 20f;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

            animator.SetBool("Jump", true);

            Invoke("CancelMushroomAnimation", 0.5f);
        }

    }

    void CancelMushroomAnimation()
    {
        animator.SetBool("Jump", false);
    }
}
