using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript2 : MonoBehaviour
{
    //private HealthBarScript HP;
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //  HP.health -= 10f;
    //}
    //void Start()
    //{
    //   HP = GameObject.Find("HealthBar").GetComponent<HealthBarScript>();
    //}
    void OnTriggerEnter2D(Collider2D col)
    {
        HealthBarScript.health -= 10f;
    }
}