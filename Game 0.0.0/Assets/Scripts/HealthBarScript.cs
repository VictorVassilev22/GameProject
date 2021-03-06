﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    Image healthBar;
    Image shieldBar;
    public GameObject shieldText;
    public static float shieldPoints = 0f;
    public static float shieldGain = 10f;
    public static float maxHealth = 100f;
    public static float health=100f;
    public static bool canTakeDamage = true;

    private GameObject player;
    public GameObject disappearingAnimation;

    public static bool canBreakShield = false;

    void Start () {
        player = GameObject.Find("Player");
        healthBar = GetComponent<Image> ();
        shieldBar = GameObject.Find("ShieldBar").GetComponent<Image>();
        shieldText.SetActive(false);
        health = maxHealth;
		
	}
	
	void Update () {
        if (health <= 0)
        {
            health = 0;
            canTakeDamage = false;
        }
        else
        {
            canTakeDamage = true;
        }

        if (health > maxHealth)
            health = maxHealth;

        if (PowerUpActivation.powerupEnablers[1]&&shieldPoints>0)
        {
            canBreakShield = true;
            shieldText.SetActive(true);
            shieldText.GetComponent<TextMesh>().text = "+ " + shieldPoints.ToString();
            if (shieldPoints + health >= maxHealth)
            {
                shieldBar.fillAmount = 1;
                healthBar.fillAmount = health / (maxHealth + shieldPoints);
            }
            else
            {
                healthBar.fillAmount = health / maxHealth;
                shieldBar.fillAmount = (health + shieldPoints) / maxHealth;
            }
        }
        else
        {
            healthBar.fillAmount = health / maxHealth;
            shieldBar.fillAmount = 0;
            shieldPoints = 0;
            PowerUpActivation.powerupEnablers[1] = false;
            Destroy(PowerUpActivation.instances[1]);
            shieldText.SetActive(false);

            if (canBreakShield)
            {
                GameController.ShowPowerUpAnimation(disappearingAnimation, player.transform);
                PowerUpActivation.FreeCooldownBarPositions(PowerUpActivation.instances[1]);
                canBreakShield = false;
            }
        }
	}
}
