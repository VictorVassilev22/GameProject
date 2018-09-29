using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    //shield power-up with index 1 is linked with health bar script and health trigger script
    //magnet power-up with index 0 is liked with coin script

    private PowerUpActivation activation;
    public int index;
    private void Awake()
    {
        activation = GameObject.Find("GameController").GetComponent<PowerUpActivation>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            if (index == 1&&HealthBarScript.shieldPoints<=HealthBarScript.maxHealth)
                HealthBarScript.shieldPoints += HealthBarScript.shieldGain;

            activation.Activate(index);
            Destroy(this.gameObject);
        }
    }

}