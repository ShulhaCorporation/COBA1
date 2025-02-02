using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetector : MonoBehaviour
{
    public event Action OnBossPoint;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("BossPoint"))
        {
            OnBossPoint?.Invoke();
        }
    }
}
