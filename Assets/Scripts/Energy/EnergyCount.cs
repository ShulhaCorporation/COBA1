using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCount : MonoBehaviour
{
   public float power = 1f;
    
    

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
            power -= 0.4f * Time.deltaTime;
        }
      if(power < 1 && !playerInput.IsFlyPressed)
        {
            power += 0.07f * Time.deltaTime;
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