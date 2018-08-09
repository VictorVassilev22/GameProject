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
            if (HealthBarScript.health<damage)
            {
                GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(HealthBarScript.health);
                HealthBarScript.health = 0;
            }
            else
            {
                HealthBarScript.health -= damage;
                GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(damage);
            }
            canTrigger = false;
        }
    }

    private void Update()
    {
        if (this.GetComponentInParent<Transform>().position.y <= -8.5f || 
            !GameController.gameRunning) canTrigger = false;
    }
}