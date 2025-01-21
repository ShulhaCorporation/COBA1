using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Timer : AResetable
{
    [SerializeField]
    private int time;
    [SerializeField]
    private GameObject label;
    [SerializeField]
    private PlayerDeath playerDeath;
    public event Action OnTick;
    private int seconds;
    private Coroutine countdown;
    public void StartTime()
    {
        seconds = time;
        playerDeath.OnDeath += StopTimer;
        label.SetActive(true);
       countdown = StartCoroutine(StartTimer());

    }

    IEnumerator StartTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (seconds > 0)
        {
            yield return wait;     
            seconds--;
            OnTick.Invoke();
        }
    }
   public int GetSeconds()
    {
        return seconds;
    }
    public override void ResetItem()
    {
        seconds = time;
            StopCoroutine(countdown);
       countdown = StartCoroutine(StartTimer());
    }
    private void StopTimer()
    {
        StopCoroutine(countdown);
    }
}
