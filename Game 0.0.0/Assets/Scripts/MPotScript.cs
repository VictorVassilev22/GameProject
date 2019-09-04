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
            if (PauseMenuScript.ctrlScript.gameRunning)
            {
                if (ManaBarScript.maxMana < ManaBarScript.mana + gain)
                {
                    float currentGain = ManaBarScript.maxMana - ManaBarScript.mana;
                    GameController.ShowTextEffect(currentGain, text, col.transform);
                    ManaBarScript.mana += currentGain;
                }
                else
                {
                    GameController.ShowTextEffect(gain, text, col.transform);
                    ManaBarScript.mana += gain;
                }
                PotionEffect.ActivateEffect(col.transform, manaEffect);
            }
        }
    }
}
