using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour {
    private SpriteRenderer sprRend;

    private void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D col)
     {
         if(col.gameObject.name == "EnemySprite")
         {
            StartCoroutine(ChangeeColor());
         }
     }
    IEnumerator ChangeeColor()
    {
        sprRend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprRend.color = Color.white;
    }
}
