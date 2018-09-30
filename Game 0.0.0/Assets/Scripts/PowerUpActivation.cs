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
    private float[] durations = new float[4];
    private float[] timeLefts = new float[4];
    private Image[] fillBars = new Image[4];

    public static List<bool> orderedBars = new List<bool> {false,false,false,false };

    private void Start()
    {
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
                }
                else
                {
                    powerupEnablers[i] = false;
                    Destroy(instances[i]);
                }
            }
        }
    }
  
     void ShowTimeBar(int index)
    {
        
       Vector2 position = CalculateTimerPosition(index);
       
       instances[index] = Instantiate(timers[index], position, Quaternion.identity);
        fillBars[index] = instances[index].gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    }

    Vector2 CalculateTimerPosition(int index)
    {
        Vector2 position = new Vector2();

            if (!orderedBars[0]) {
                position = new Vector2(2.6f, -10);
                orderedBars[0] = true;
            StartCoroutine(TimerQueing(0,index,durations[index]));
            }
            else if (!orderedBars[1])
            {
                position = new Vector2(-2.85f, -10);
                orderedBars[1] = true;
            StartCoroutine(TimerQueing(1,index, durations[index]));
        }
            else if (!orderedBars[2])
            {
                position = new Vector2(2.6f, -9.2f);
                orderedBars[2] = true;
            StartCoroutine(TimerQueing(2,index, durations[index]));
        }
            else if (!orderedBars[3])
            {
                position = new Vector2(-2.85f, -9.2f);
                orderedBars[3] = true;
            StartCoroutine(TimerQueing(3,index, durations[index]));
        }
                
        return position;
    }

    public static bool CanDropPowerUp()
    {
        bool can = false;
        for (int i = 0; i < orderedBars.Count; i++)
        {
            if (!orderedBars[i])
                can = true;
        }
        return can;
    }

    IEnumerator TimerQueing(int place, int index,float duration)
    {
        yield return new WaitForSeconds(duration);
        if (!powerupEnablers[index]) orderedBars[place] = false;
        else StartCoroutine(TimerQueing(place, index, 2f));
    }
}
