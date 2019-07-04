using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpActivation : MonoBehaviour {

    public static bool[] powerupEnablers= {false,false,false,false};

    public GameObject timeBar0;
    public float duration0 = 10f;
    public GameObject timeBar1;
    public float duration1 = 20f;
    public GameObject timeBar2;
    public float duration2 = 10f;
    public GameObject timeBar3;
    public float duration3 = 10f;

    public static GameObject[] timers= new GameObject[4];
    public static GameObject[] instances = new GameObject[4];
    public static Vector2[] positions = new Vector2[4]{ new Vector2(0.5f, -9.75f), new Vector2(-4.1f, -9.75f),
        new Vector2(2.6f, -9.2f), new Vector2(-2.9f, -9.2f) };
    private float[] durations = new float[4];
    private float[] timeLefts = new float[4];
    private Image[] fillBars = new Image[4];

    public static List<bool> orderedBars = new List<bool> {false,false,false,false };

    private GameObject player;
    public GameObject disappearingAnimation;

    private void Start()
    {
        player = GameObject.Find("Player");
        timers[0]=timeBar0;
        durations[0] = duration0;
        timeLefts[0] = 0;

        timers[1] = timeBar1;
        durations[1] = duration1;
        timeLefts[1] = 0;

        timers[2] = timeBar2;
        durations[2] = duration2;
        timeLefts[2] = 0;

        timers[3] = timeBar3;
        durations[3] = duration3;
        timeLefts[3] = 0;
    }

    public void Activate(int index)
    {
       
        timeLefts[index] = durations[index];
        if (!powerupEnablers[index] && durations[index] > 0)
        {
            powerupEnablers[index] = true;
            ShowTimeBar(index);
        }     
    }

    private void Update()
    {
        for (int i = 0; i < timers.Length; i++)
        {
            if (powerupEnablers[i])
            {
                if (timeLefts[i] > 0)
                {
                    powerupEnablers[i] = true;
                    timeLefts[i] -= Time.deltaTime;
                    fillBars[i].fillAmount = timeLefts[i] / durations[i];

                    CheckForFreeSpaces(i);
                }
                else
                {
                    powerupEnablers[i] = false;

                    if (HealthBarScript.canBreakShield&&i==1)
                    {
                        GameController.ShowPowerUpAnimation(disappearingAnimation, player.transform);
                        HealthBarScript.canBreakShield = false;
                    }
                    FreeCooldownBarPositions(instances[i]);
                    Destroy(instances[i]);
                }
            }
        }
    }
  
    void CheckForFreeSpaces(int index)
    {
        int biggestTakenPlace = -1;
        bool needsToReplace = false;

        for (int i = 0; i < 4; i++)
        {
            if (orderedBars[i])
                biggestTakenPlace = i;
        }

        if (biggestTakenPlace >= 0)
        {
            for (int i = biggestTakenPlace; i >= 0; i--)
            {
                if (!orderedBars[i])
                    needsToReplace = true;
            }
        }

        if (needsToReplace)
        {
            Destroy(instances[index]);
            FreeCooldownBarPositions(instances[index]);
            ShowTimeBar(index);
        }
    }

     void ShowTimeBar(int index)
    {
        
       Vector2 position = CalculateTimerPosition();
       
       instances[index] = Instantiate(timers[index], position, Quaternion.identity);
        fillBars[index] = instances[index].gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }


    Vector2 CalculateTimerPosition()
    {
        Vector2 position = new Vector2();
        for (int i = 0; i < 4; i++)
        {
            if (!orderedBars[i])
            {
                position = positions[i];
                orderedBars[i] = true;
                break;
            }
        }
           
        return position;
    }

    public static void FreeCooldownBarPositions(GameObject instance)
    {

        Vector2 position = instance.transform.position;
        for (int i = 0; i < 4; i++)
        {
            if (position == positions[i])
            {
                orderedBars[i] = false;
            }
        }
    }

    public static void NullOrderedBarsList()
    {
        for (int i = 0; i < 4; i++)
        {
           orderedBars[i] = false;
        }
    }
}
