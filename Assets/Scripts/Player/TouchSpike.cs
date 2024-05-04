using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TouchSpike : MonoBehaviour
{
    private LifeSystem lifeset;
    void Start()
    {
        lifeset = GetComponent<LifeSystem>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Deadly")
        { 
            lifeset.AddHp(-1);
            Thread.Sleep(1000);
        }
    }
}
