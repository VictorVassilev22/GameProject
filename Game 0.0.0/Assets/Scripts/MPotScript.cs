using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPotScript : MonoBehaviour {

    public GameObject manaEffect;

    void Update()
    {
        if (this.transform.position.y <= -13)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            if (GameController.gameRunning)
            {
                PotionEffect.ActivateEffect(col.transform, manaEffect);
                ManaBarScript.mana += 20f;
            }
        }
    }
}
