using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{

    public GiantHedgehog whichGiantHedgehog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple")
        {
            whichGiantHedgehog.appleTrigger = true;
        }
    }
}
