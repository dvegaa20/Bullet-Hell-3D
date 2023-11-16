using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float realTimeSeconds = 10.0f;
    private float timer;

    // Referencia a MyFunctions
    public ShootingMode shootingMode;

    private void Start()
    {
        shootingMode = GetComponent<ShootingMode>();

        Minute = 0;
        Hour = 0;

        // Invoca repetidamente el método RepeatAction cada 10 segundos
        InvokeRepeating("RepeatAction", 0.0f, realTimeSeconds);
    }

    private void Update()
    {
        UpdateGameTime();
    }

    private void UpdateGameTime()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Minute++;

            OnMinuteChanged?.Invoke();

            if(Minute >= 60)
            {
                Hour++;
                OnHourChanged?.Invoke();
                Minute = 0;
            }
            timer = realTimeSeconds;
        }  
    }

    // Este método se ejecutará cada 10 segundos en tiempo real
    private void RepeatAction()
    {
        // Llama a tus tres funciones desde MyFunctions
        shootingMode.BurstShot();
        shootingMode.CircleShot();
        shootingMode.SpiralShot();
    }
}
