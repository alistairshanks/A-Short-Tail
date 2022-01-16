using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;

    float Horizontal;

    float Vertical;

    Animator animator;

    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        Vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(Horizontal, Vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))

        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();

        }

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);






        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * Horizontal;
        position.y = position.y + speed * Vertical;

        rigidbody2d.MovePosition(position);

    }

    
}
