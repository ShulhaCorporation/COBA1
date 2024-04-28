using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCount : MonoBehaviour
{
   public float power = 1f;
    [SerializeField]
    private int delay = 100;
    
    [SerializeField]
    Movement movement;

    [SerializeField]
    EnergyDraw energyDraw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && power > 0)
        {
            Thread.Sleep(delay);
            power -= 0.1f;
        }
      if(power < 1 && !Input.GetKey(KeyCode.Space))
        {
            Thread.Sleep(delay);
            power += 0.1f;
        }
      if(power <= 0)
        {
            movement.SetCanFly(false);
        }
      if (power > 0)
        {
            movement.SetCanFly(true);
        }
        energyDraw.SetEnergy(power);
    }
}