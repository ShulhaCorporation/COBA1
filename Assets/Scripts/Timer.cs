using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject label;
    public event Action OnTick;
    private int seconds = 120;
    public void StartTime()
    {
        label.SetActive(true);
        StartCoroutine(StartTimer());

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
}
