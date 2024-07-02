using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{    
    public event Action OnplayerDetected;
    void OnTriggerEnter2D(Collider2D cl)
    {
    
        if(cl.gameObject.tag == "Player")
        {
            OnplayerDetected.Invoke();
        }
    }
}
