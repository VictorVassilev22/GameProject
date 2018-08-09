using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    Image healthBar;
    public static float maxHealth = 100f;
    public static float health;
    public static bool canTakeDamage = true;

	void Start () {
        healthBar = GetComponent<Image> ();
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
        healthBar.fillAmount = health / maxHealth;
        if (health > maxHealth) health = maxHealth;
	}
}
