using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Hp1: MonoBehaviour
{
    private Vector3 scale;
    private LifeSystem lifeSystem;
    void Start()
    {
        lifeSystem = GetComponent<LifeSystem>();
    }

    
    void Update()
    {
        scale = transform.localScale;
        if(lifeSystem.GetHp() < 1 && scale != new Vector3(0f,0f,1f))
        {
            for (int i = 0; i < 101; i++) {
             transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
               Thread.Sleep(1);
           }
        }
    }
}