using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnSecondChanged;
    public static Action OnMinuteChanged;

    public static int Second{get; private set;}
    public static int Minute{get;private set;}

    private float secondToRealTime = 1f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Second = 0;
        Minute = 0;
        timer = secondToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Second++;

            OnSecondChanged?.Invoke();

            if(Second >= 60)
            {
                Minute++;
                OnMinuteChanged?.Invoke();
                Second = 0;
            }

            timer = secondToRealTime;
        }   
    }
}
