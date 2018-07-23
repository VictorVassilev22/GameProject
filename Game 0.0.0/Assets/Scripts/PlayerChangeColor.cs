using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour {
 void OnTriggerEnter2D(Collider2D col)
     {
         if(col.gameObject.tag == "Enemy")
         {
             col.gameObject.GetComponent<Renderer>().material.color = Color.red;
         }
     }

}
