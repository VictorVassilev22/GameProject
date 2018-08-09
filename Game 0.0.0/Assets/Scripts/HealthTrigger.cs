using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthTrigger : MonoBehaviour
{
    public bool canTrigger = true;
    public float damage = 10f;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && canTrigger && HealthBarScript.canTakeDamage)
        {
            HealthBarScript.health -= damage;
            canTrigger = false;
            GameObject.Find("Player").GetComponent<PlayerGetsHit>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        if (this.GetComponentInParent<Transform>().position.y <= -8.5f || 
            !GameController.gameRunning) canTrigger = false;
    }
}