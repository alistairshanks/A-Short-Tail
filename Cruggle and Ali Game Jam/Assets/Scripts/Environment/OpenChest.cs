using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{

    public Animator animator;
    public GameObject chicken;
    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("ChestOpen", true);

        Invoke("SpawnChicken", 0.7f);

        Invoke("PlayerWinsGame", 1.5f);

    }

    void SpawnChicken()
    {
        chicken.SetActive(true);
    }

    void PlayerWinsGame()
    {
        GameManager1.instance.PlayerWin();
    }

}
