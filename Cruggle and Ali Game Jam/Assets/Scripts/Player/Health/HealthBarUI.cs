using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Image Health;
    public float currentHealth;
    private float maxHealth = 100f;
    CharacterController2D Player;

    private void Start()
    {
        Health = GetComponent<Image>();
        Player = FindObjectOfType<CharacterController2D>();
    }

    private void Update()
    {
        currentHealth = Player.currentHealth;
        Health.fillAmount = currentHealth / maxHealth;
    }

}
