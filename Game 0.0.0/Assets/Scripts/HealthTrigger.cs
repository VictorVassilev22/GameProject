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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player" && canTrigger && HealthBarScript.canTakeDamage)
        {
            PlayerDamageHandler();
        }
        EnemyDamageHandler(col);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && canTrigger && HealthBarScript.canTakeDamage)
        {
            if (this.gameObject.tag == "Enemy")
            {
                if (canAttackAnimation) this.gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("attack");
                canAttackAnimation = false;
            }
            PlayerDamageHandler();
        }
        EnemyDamageHandler(col);
    }
    

    private void Update()
    {
        if ((this.GetComponentInParent<Transform>().position.y <= -8f  || 
            !GameController.gameRunning)&&this.gameObject.tag!="EnemyHazard") canTrigger = false;

        if (this.gameObject.tag == "Enemy" && Mathf.Abs(this.transform.position.x-player.transform.position.x)<=1.5f
            && Mathf.Abs(this.transform.position.y - player.transform.position.y) <= 3f && canTrigger)
        {
            if(canAttackAnimation) this.gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("attack");
            canAttackAnimation = false;
            
        }
    }
    private void EnemyDamageHandler(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (this.gameObject.name == "Ex-Bomb(Clone)")
                col.gameObject.GetComponent<EnemyScript>().health = 0;
            else
                col.gameObject.GetComponent<EnemyScript>().health -= damage;
        }
    }

    private void EnemyDamageHandler(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (this.gameObject.name == "Ex-Bomb(Clone)")
                col.gameObject.GetComponent<EnemyScript>().health = 0;
            else
                col.gameObject.GetComponent<EnemyScript>().health -= damage;
        }
    }

    private void PlayerDamageHandler()
    {
        if (HealthBarScript.health + HealthBarScript.shieldPoints < damage)
        {
            player.GetComponent<PlayerGetsHit>().TakeDamage(HealthBarScript.health, this.gameObject.tag);
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
                    player.GetComponent<PlayerGetsHit>().TakeDamage(damage - HealthBarScript.shieldPoints, this.gameObject.tag);
                    HealthBarScript.shieldPoints = 0;
                    PowerUpActivation.FreeCooldownBarPositions(PowerUpActivation.instances[1]);
                }
            }
            else
            {
                HealthBarScript.health -= damage;
                player.GetComponent<PlayerGetsHit>().TakeDamage(damage, this.gameObject.tag);
            }
        }
        canTrigger = false; 
    }
}