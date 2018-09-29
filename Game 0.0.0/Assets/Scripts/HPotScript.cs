using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPotScript : MonoBehaviour {
    public GameObject healthEffect;
    public GameObject text;
    public float gain = 20f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            if (GameController.gameRunning)
            {
                if (HealthBarScript.maxHealth<HealthBarScript.health+gain)
                {
                    GameController.ShowTextEffect(HealthBarScript.maxHealth-HealthBarScript.health, text, col.transform);
                }
                else
                {
                    GameController.ShowTextEffect(gain, text, col.transform);
                }
                HealthBarScript.health += gain;
                PotionEffect.ActivateEffect(col.transform, healthEffect);
            }
        }
    }

}
