using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCenterController : MonoBehaviour
{
    private static int savedLoot;


    // Start is called before the first frame update+-
    void Start()
    {
        savedLoot = PlayerPrefs.GetInt("SavedLootInt", 0);
        //savedLoot += PlayerPrefs.GetInt("Loot", 0);
        //PlayerPrefs.SetInt("SavedLootInt", savedLoot);
        PlayerPrefs.SetString("SavedLoot", savedLoot.ToString());
        GameObject.Find("Counter").GetComponent<TextMesh>().text = PlayerPrefs.GetString("SavedLoot", "0");
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
