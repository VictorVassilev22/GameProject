using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthTrigger : MonoBehaviour
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
        if(col.gameObject.name=="Player")
        HealthBarScript.health -= 10f;
    }
}