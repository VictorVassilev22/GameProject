using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthTrigger : MonoBehaviour
{
    public bool canTrigger = true;
    public float damage = 6f;
    private EnemyScript enemyScr;

    void OnTriggerStay2D(Collider2D col)
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
                        PowerUpActivation.FreeCooldownBarPositions(PowerUpActivation.instances[1]);
                    }
                }
                else
                {
                    HealthBarScript.health -= damage;
                    GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(damage);
                }
            }
             canTrigger = false;
            if (this.gameObject.name == "Bomb" || this.gameObject.name == "Bomb(Clone)") Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (this.GetComponentInParent<Transform>().position.y <= -8f  || 
            !GameController.gameRunning) canTrigger = false;
    }
}