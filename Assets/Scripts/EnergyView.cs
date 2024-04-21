using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetEnergy(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetEnergy(float energy){
        if (energy >= 0 && energy <=1 ) 
            transform.localScale = new Vector3(energy, 1,1);
    }
}
