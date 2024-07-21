using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    public event Action OnGroundDetected;

   
    private const string GroundTag = "Ground";

    void OnTriggerEnter2D(Collider2D collision){
     
        if(collision.gameObject.tag == GroundTag)
        {
            OnGroundDetected?.Invoke();
            
        }
    }
}
