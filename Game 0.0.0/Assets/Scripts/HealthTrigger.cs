using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthTrigger : MonoBehaviour
{
    public bool canTrigger = true;
    public float damage = 6f;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && canTrigger && HealthBarScript.canTakeDamage)
        {
            if (HealthBarScript.health+HealthBarScript.shieldPoints<damage)
            {
                GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(HealthBarScript.health);
                HealthBarScript.health = 0;
            }

            else
            {
                if (PowerUpActivation.powerupEnablers[1])
                {
                    if (HealthBarScript.shieldPoints >= damage)
                        HealthBarScript.shieldPoints -= damage;
                    else
                    {
                        HealthBarScript.health -= damage - HealthBarScript.shieldPoints;
                        GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(damage-HealthBarScript.shieldPoints);
                        HealthBarScript.shieldPoints = 0;
                        Vector2 position = PowerUpActivation.timers[1].transform.position;
                        PowerUpActivation.orderedBars[1] = false;
                        if (position == new Vector2(2.6f, -10))
                        {
                            PowerUpActivation.orderedBars[0] = false;
                        }
                        else if (position == new Vector2(-2.85f, -10))
                        {
                            PowerUpActivation.orderedBars[1] = false;
                        }
                        else if (position == new Vector2(2.6f, -9.2f))
                        {
                            PowerUpActivation.orderedBars[2] = false;
                        }
                        else if (position == new Vector2(-2.85f, -9.2f))
                        {
                            PowerUpActivation.orderedBars[3] = false;
                        }
                    }
                }
                else
                {
                    HealthBarScript.health -= damage;
                    GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(damage);
                }
            }
            canTrigger = false;
        }
    }

    private void Update()
    {
        if (this.GetComponentInParent<Transform>().position.y <= -8f || 
            !GameController.gameRunning) canTrigger = false;
    }
}