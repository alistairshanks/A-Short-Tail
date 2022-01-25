using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitProximity : MonoBehaviour
{

    public HedgehogScript thisHedgehog;
    public Transform hedgehogPosition;
    private void Update()
    {
        transform.position = hedgehogPosition.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("player is away");
        if (collision.tag == "Player")
        thisHedgehog.isSpiked = false;

        

    }
}
