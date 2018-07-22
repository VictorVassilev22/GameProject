using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour {
    
    Image manaBar;
    float maxMana = 101f;
    public static float mana ;
    public float cooldown = 1.0f;
	void Start () {
        manaBar = GetComponent<Image>();
        mana = maxMana;
	}
	
	
	void Update () {
        manaBar.fillAmount = mana / maxMana;
	}

}
