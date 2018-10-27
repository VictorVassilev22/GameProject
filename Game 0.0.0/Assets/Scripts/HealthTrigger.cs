using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthTrigger : MonoBehaviour
{
    public bool canTrigger = true;
    private bool canAttackAnimation = true;

    public float damage = 6f;
    private EnemyScript enemyScr;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && canTrigger && HealthBarScript.canTakeDamage)
        {
            if (this.gameObject.tag=="Enemy")
            {
               if(canAttackAnimation) this.gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("attack");
                canAttackAnimation = false;
            }

            if (HealthBarScript.health+HealthBarScript.shieldPoints<damage)
            {
               player.GetComponent<PlayerGetsHit>().TakeDamage(HealthBarScript.health);
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
                        player.GetComponent<PlayerGetsHit>().TakeDamage(damage-HealthBarScript.shieldPoints);
                        HealthBarScript.shieldPoints = 0;
                        PowerUpActivation.FreeCooldownBarPositions(PowerUpActivation.instances[1]);
                    }
                }
                else
                {
                    HealthBarScript.health -= damage;
                    player.GetComponent<PlayerGetsHit>().TakeDamage(damage);
                }
            }
             canTrigger = false;
            //if (this.gameObject.name == "Bomb" || this.gameObject.name == "Bomb(Clone)") Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (this.GetComponentInParent<Transform>().position.y <= -8f  || 
            !GameController.gameRunning) canTrigger = false;

        if (this.gameObject.tag == "Enemy" && Mathf.Abs(this.transform.position.x-player.transform.position.x)<=1f
            && Mathf.Abs(this.transform.position.y - player.transform.position.y) <= 2.5f && canTrigger)
        {
            if(canAttackAnimation) this.gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("attack");
            canAttackAnimation = false;
            
        }
    }
}