using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    //shield power-up with index 1 is linked with health bar script and health trigger script
    //magnet power-up with index 0 is liked with coin script

    private PowerUpActivation activation;
    public int index;
    private float shieldPoints;
    private float shieldGain;
    private float maxHealth;

    private GameObject player;
    public GameObject appearingAnimation;

    public GameObject barrier;

    private void Awake()
    {
        player = GameObject.Find("Player");
        activation = GameObject.Find("GameController").GetComponent<PowerUpActivation>();

        shieldPoints = HealthBarScript.shieldPoints;
        shieldGain = HealthBarScript.shieldGain;
        maxHealth = HealthBarScript.maxHealth;
  

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            if (index == 1 && shieldPoints <= maxHealth)
            {
                if (shieldPoints + shieldGain > maxHealth)
                {
                    HealthBarScript.shieldPoints = HealthBarScript.maxHealth;
                }else
                HealthBarScript.shieldPoints += HealthBarScript.shieldGain;
            }

            if (index == 1)
            {
                GameController.ShowPowerUpAnimation(appearingAnimation, player.transform);
                if (!PowerUpActivation.powerupEnablers[1])
                    Instantiate(barrier, new Vector2(player.transform.position.x, player.transform.position.y-0.6f), Quaternion.identity, player.transform);
            }

            activation.Activate(index);
            Destroy(this.gameObject);
        }
    }

}