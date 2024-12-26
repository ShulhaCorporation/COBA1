using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class TriggerBoss : MonoBehaviour
{
  
    public event Action OnBossTriggered;
    private bool dontCall = false;
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !dontCall)
        {
            OnBossTriggered.Invoke();
            dontCall = true;
            transform.eulerAngles = new Vector3(0,180,0);
           

        }
    }
   
}
