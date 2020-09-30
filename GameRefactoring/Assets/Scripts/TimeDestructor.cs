using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TimeDestructor : MonoBehaviour
{
    [SerializeField]
    float destroyAfter;

    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        //adding timer to the object
        timer = this.gameObject.AddComponent<Timer>();
        //setting seconds to timer
        timer.IsFixed = true;
        timer.FixedTime = destroyAfter;
        //run the timer
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //when time is up, destroy the object
        if (!timer.IsRunning)
            Destroy(gameObject);
    }
}
