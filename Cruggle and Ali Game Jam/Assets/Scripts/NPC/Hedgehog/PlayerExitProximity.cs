using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitProximity : MonoBehaviour
{

    public HedgehogScript thisHedgehog;
    public Transform hedgehogPosition;
    private void Update()
    {
        if (thisHedgehog != null)
        {
            transform.position = hedgehogPosition.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (thisHedgehog != null)
        {
            if (collision.tag == "Player")
            {
                thisHedgehog.isSpiked = false;
            }
        }
        

        

    }
}
