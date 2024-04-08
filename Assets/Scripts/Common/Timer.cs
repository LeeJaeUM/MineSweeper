using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action<int> onTimeChange;
    float elapsedTime = 0;
    public float ElapsedTime
    {
        get => elapsedTime;
        set
        {
            if(elapsedTime !=  value)
            {
                elapsedTime = value;
                onTimeChange?.Invoke((int)elapsedTime);
            }
        }
    }


    IEnumerator timeCoroutine;
    private void Start()
    {
        GameManager manager = GameManager.Instance;
        manager.onGameReady += TimerReset;
        manager.onGamePlay += TimerReset;
        manager.onGamePlay += Play;
        manager.onGameGameClear += Stop;
        manager.onGameGameOver += Stop;

        timeCoroutine = Timer_Co();
    }
    

    private void Stop()
    {
        StopCoroutine(timeCoroutine);
    }

    private void Play()
    {
        StartCoroutine(timeCoroutine);
    }

    private void TimerReset()
    {
        ElapsedTime = 0; 
    }

    IEnumerator Timer_Co()
    {
        while(true)
        {
            ElapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
