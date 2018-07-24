using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthTrigger : MonoBehaviour
{
    private bool canTrigger = true;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && canTrigger)
        {
            HealthBarScript.health -= 10f;
            canTrigger = false;
            GameObject.Find("Player").GetComponent<PlayerChangeColor>().changeColor();
        }
    }
}