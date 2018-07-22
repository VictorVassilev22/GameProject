﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour {
    
    Image manaBar;
    float maxMana = 101f;
    public static float mana ;
    public float cooldown = 3f;
    public static bool hasManaForMissle = true;
	void Start () {
        manaBar = GetComponent<Image>();
        mana = maxMana;
        StartCoroutine(ManaAddWait());
	}
	
	
	void Update () {
        manaBar.fillAmount = mana / maxMana;
        if (mana <= 10f) hasManaForMissle = false;
        else hasManaForMissle = true;
	}

    IEnumerator ManaAddWait()
    {
        yield return new WaitForSeconds(cooldown);
        if(mana<=maxMana) mana += 5f;
        if (mana > maxMana) mana = 101f;
        StartCoroutine(ManaAddWait());
    }
}
