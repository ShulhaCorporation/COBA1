using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDraw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetEnergy(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetEnergy(float energy)
    { if (energy >= 0 && energy <= 1)
            transform.localScale = new Vector3(energy, 1, 1);

    }
}

