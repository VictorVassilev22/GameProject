using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetFieldActivation : MonoBehaviour {

    public static float duration = 20f;
    private static float timeLeft;
    public static bool magnetFieldEnabled = false;
    private static MagnetFieldActivation instance;
    private Image fillBar;
    public GameObject timeBar;
    private GameObject instanceOfBar;

    private static bool barActive=false;

    private void Awake()
    {
        instance = this;
        timeLeft = 0;
    }

    public static void Activate()
    {

            magnetFieldEnabled = true;
            timeLeft = duration;
            if(!barActive) instance.ShowTimeBar();      
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            fillBar.fillAmount = timeLeft/duration;
        }
        else
        {
            magnetFieldEnabled = false;
            Destroy(instanceOfBar);
            barActive = false;
        }
    }
  
     void ShowTimeBar()
    {
        instanceOfBar = Instantiate(timeBar, new Vector2(timeBar.transform.position.x, timeBar.transform.position.y), Quaternion.identity);
        fillBar = instanceOfBar.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        barActive = true;
    }
}
