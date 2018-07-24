using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour {
    private SpriteRenderer sprRend;

    private void Start()
    {
        sprRend = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }
    public void changeColor()
     {
                StartCoroutine(ChangeColor());
     }
    IEnumerator ChangeColor()
    {
        sprRend.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprRend.color = Color.white;
    }
}
