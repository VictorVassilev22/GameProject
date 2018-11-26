using System.Collections;
using UnityEngine;

public class PlayerGetsHit : MonoBehaviour {
    private SpriteRenderer sprRend;
    public GameObject damageText;

    private void Start()
    {
        sprRend = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage, string tag)
     {  
        StartCoroutine(ChangeColorTime(damage, tag));

     }

    IEnumerator ChangeColorTime(float damage, string tag)
    {
        if (tag == "Enemy")
        {
            yield return new WaitForSeconds(0.25f);
        }

        if (damageText)
            GameController.ShowTextEffect(-damage, damageText, this.transform);
        sprRend.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sprRend.color = Color.white;
    }
}
