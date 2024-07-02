using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    public event Action OnGroundDetected;

    [SerializeField]
    private const string GroundTag = "Ground";

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == GroundTag)
        {
            OnGroundDetected.Invoke();
        }
    }
}
