using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class test2 : MonoBehaviour
{
     private GeyserSwitching switching;
    void Start()
    {
        switching = gameObject.GetComponent<GeyserSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(switching.GetInfo());      
    }
}
