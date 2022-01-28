using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController2D.instance.ChangeHealth(33);
        Destroy(gameObject);
    }

  
}
