using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foxmovement : MonoBehaviour
{
    public FoxController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    
    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
    }

    private void FixedUpdate()
    {
        //moves character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
