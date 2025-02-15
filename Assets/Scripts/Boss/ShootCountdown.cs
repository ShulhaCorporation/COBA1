using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCountdown : MonoBehaviour
{
    public event Action OnCountdownEnd;
    public void StartCountdown(float time)
    {
        StartCoroutine(Timer(time));
    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        OnCountdownEnd?.Invoke();
    }
}
