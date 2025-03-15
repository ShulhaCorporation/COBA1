using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayer : MonoBehaviour
{
    public event Action OnDelayEnd;
   public void Wait(float delay)
    {
        StartCoroutine(Delay(delay));
    }
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDelayEnd?.Invoke();
    }
}
