﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Timer : MonoBehaviour
{
  

    #region Fields

    // if we have a threshold where to stop (like a chronometer)
    [SerializeField]
    bool isFixed = false;

    // value of the threshold
    [SerializeField]
    float duration = -1f;

    //is the timer running
    bool isRunning = false;
    //how many time has passed
    float timePassed = 0f;

    #endregion

    #region Properties
    public bool IsRunning
    {
        get { return isRunning; }
    }

    public bool IsFixed
    {
        get { return IsFixed; }
        set { isFixed = value; }
    }

    public float Duration
    {
        get { return isFixed ? duration : -1f; }
        set { duration = value; }
    }

    public float TimePassed
    {
        get { return timePassed; }
    }



    #endregion

    #region Methods
    /// <summary>
    /// adding time every frame
    /// time.deltaTime returns how many seconds it took for the last frame to execute
    /// </summary>
    private void Update()
    {

        if (isFixed)
        {
            if (timePassed >= duration)
            {
                Pause();
            }
        }

        if(isRunning)
            timePassed += Time.deltaTime;
        
    }

    public void Pause()
    {
        isRunning = false;
    }

    public void Run()
    {
        if (isFixed && timePassed >= duration)
            return;
            
        isRunning = true;
    }

    public void Restart()
    {
        timePassed = 0f;
        Run();
    }

    #endregion


}
