using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuScript : MonoBehaviour
{
    public TextMesh loot;
    public TextMesh totalCoin;
    public float duration = 2f;

    private int intLoot;
    private int intTotalCoin;

    void Start()
    {
        intTotalCoin = PlayerPrefs.GetInt("SavedLootInt", 0);
        intLoot = PlayerPrefs.GetInt("Loot", 0);
        loot.text = intLoot.ToString();
        totalCoin.text = PlayerPrefs.GetString("SavedLoot");
        StartCoroutine(addLoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator addLoot()
    {
        int start = intTotalCoin;
        int target = intTotalCoin + intLoot;
        PlayerPrefs.SetInt("SavedLootInt", target);

        for (float timer = 0; timer <= duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            intTotalCoin = (int)Mathf.Lerp(start, target+1, progress);
            totalCoin.text = intTotalCoin.ToString();
            yield return null;
        }
       
        
    }
}
