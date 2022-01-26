using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // declare a variable to contain the position of the character we want the camera to follow
    public Transform followTarget;
    // declare a variable to contain an offset so the camera is not in exactly the character position
    public Vector3 offset;

    // declare a variable for how quickly we want the camera to follow the player, for a smoother look
    [Range(1, 10)]
    public float smoothFactor;

    private void FixedUpdate()
    {
        //call our follow method
        Follow();
    }


    void Follow()
    {
        /* store a variable called "targetPosition" which contains the position of the character 
        we want to follow plus an offset (usually on z axis to keep camera back from character) in 
        our case, this offset is set in the inspector */
        Vector3 targetPosition = followTarget.position + offset;

        /* store a new variable called "smoothPosition" and store inside it a linear transition between 
        the camera's current position and the targetPosition. Vector3.Lerp creates a line, which we use
        to create a smooth transition instead of snapping straight to the new coordinates, the smoothFactor
        determines the time it takes to get from one end of the line to the other*/
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);

        // set the position of the camera to our smoothPosition variable
        transform.position = smoothPosition;
    }

}

