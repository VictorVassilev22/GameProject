using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPotScript : MonoBehaviour {

    public GameObject manaEffect;
    public GameObject text;
    public float gain=20f;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            if (GameController.gameRunning)
            {
                PotionEffect.ActivateEffect(col.transform, manaEffect);
                ManaBarScript.mana += gain;
                GameController.ShowText(gain, text, col.transform);
            }
        }
    }
}
