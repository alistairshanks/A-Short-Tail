using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundBackgroundFollow : MonoBehaviour
{

    //variable which we can store the camera's position
    private Transform cameraTransform;

    //variable which we can store the camera's position in the previous frame
    private Vector3 lastCameraPosition;

    private float textureUnitSizeX;
    private float textureUnitSizeY;

    public bool infiniteHorizontal = true;
    public bool infiniteVertical = false;

    private void Start()
    {
        //set the camera position variable to the starting camera position of the main camera
        cameraTransform = Camera.main.transform;
        //store this position to prepare for the next frame
        lastCameraPosition = cameraTransform.position;




        //grab the sprite on the sprite renderer
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //grab the texture on that sprite
        Texture2D texture = sprite.texture;

        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
        textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) * transform.localScale.y;
        //calcualate texture unit size by dividing width by pixels per unit


    }


    private void LateUpdate()

    {
        // work out the change in movement between the current camera position
        //  and the last camera position in the previous frame 
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;



        // make the position of the background equal to it's current position
        // plus the change in movement of the camera (which is stored in deltaMovement)
        // multiplied by the scaling multiplier which decides how quickly we follow the
        //camera position
        transform.position += new Vector3(deltaMovement.x, deltaMovement.y );

        Vector3 clampedYPosition = transform.position;
        clampedYPosition.y = Mathf.Clamp(clampedYPosition.y, -999, -13);

        transform.position = clampedYPosition;
        // after the movements have been made, set the lastCamera positon to the
        // current camera position, to prepare for repeating the process next frame 
        lastCameraPosition = cameraTransform.position;

        //if the camera has moved more than the texture unit size, then move the texture
        /*  if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX * transform.localScale.x)
          {
              float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;

              transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
          }

         */
        if (infiniteHorizontal)
        {
            if (cameraTransform.position.x - transform.position.x >= textureUnitSizeX)
            {
                transform.position += new Vector3(textureUnitSizeX, 0, 0);
            }
            else if (cameraTransform.position.x - transform.position.x <= -textureUnitSizeX)
            {
                transform.position -= new Vector3(textureUnitSizeX, 0, 0);
            }
        }

        if (infiniteVertical)
        {

            if (cameraTransform.position.y - transform.position.y >= textureUnitSizeY)
            {
                transform.position += new Vector3(textureUnitSizeY, 0, 0);
            }
            else if (cameraTransform.position.y - transform.position.y <= -textureUnitSizeY)
            {
                transform.position -= new Vector3(textureUnitSizeY, 0, 0);
            }
        }
    }

}
