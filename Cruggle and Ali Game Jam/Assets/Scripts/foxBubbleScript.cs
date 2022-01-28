using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxBubbleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.anyKey)
        {
            Invoke("GetRidOfBubble", 2f);
        }

    }

    void GetRidOfBubble()
    {
        Destroy(gameObject);
    }
}
