using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform appleCarrier;
    public float rayDist;
    public bool isCarrying;
    public int facingDirection = 1;
    public bool grabSwitch = false;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            grabSwitch = !grabSwitch;
        }

        GrabAndDrop();
    }

    void GrabAndDrop()
    {

        {
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * DecideFacingDirection(), rayDist);

            if (grabCheck.collider != null && grabCheck.collider.tag == "Apple")
            {
                if (grabSwitch == true && isCarrying == false)

                {
                    Debug.Log("grab");
                    grabCheck.collider.gameObject.transform.parent = appleCarrier;
                    grabCheck.collider.gameObject.transform.position = appleCarrier.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;

                    isCarrying = true;

                }


            }
            if (grabSwitch == false && isCarrying == true)
            {
                Debug.Log("false");
                GetComponentInChildren<Rigidbody2D>().isKinematic = false;
                GetComponentInChildren<Rigidbody2D>().simulated = true;
                transform.DetachChildren();

                isCarrying = false;

            }
        }
    }

    int DecideFacingDirection()
    {
        if (CharacterController2D.instance.m_FacingRight == true)
        {
            return 1;
        }

        else
        {
            return -1;
        }
    }

   
}







