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

    private PlayerInput playerInput;
    void Start()
    {
        playerInput =  GetComponent<PlayerInput>(); // для отримання компонентів
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.IsFlyPressed && power > 0)
        {
            Thread.Sleep(delay);
            power -= 0.1f;
        }
      if(power < 1 && !playerInput.IsFlyPressed)
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