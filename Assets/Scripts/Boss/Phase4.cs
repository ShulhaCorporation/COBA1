using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  enum Phase4State
{
    DontUpdate,
    CanShoot,
    CanMove
}
public class Phase4 : iState
{    
    private BossStates bossStates;
    private Phase4State miniState = Phase4State.CanMove;
    private Cart cart;
    private GeyserController geyserController;
    private BoostSpawner spawner;
    private const int attacks = 5;
    private int attacksPlayed = 0;
    public Phase4(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }

    public void StartState()
    {
        miniState = Phase4State.CanMove;
        cart = bossStates.cart;
        geyserController = bossStates.geyserController;
        attacksPlayed = 0;
        cart.OnCartStop += EnableShooting;
        geyserController.OnAllGeysersEnd += EnableMoving;
        spawner = bossStates.boostSpawner.GetComponent<BoostSpawner>();
        spawner.SetSpawnArea(new Vector3(108.96f, 87.28f, 0), new Vector3(120.45f, 89.89f, 0));
    }

    public void UpdateState()
    {
        if (attacksPlayed >= attacks)
        {
            bossStates.Transition(bossStates.phase5);
          
        }
        else if(miniState == Phase4State.CanMove)
        {
            miniState = Phase4State.DontUpdate;
            cart.MoveRandom(0.4f);
        }
        else if(miniState == Phase4State.CanShoot)
        {    miniState = Phase4State.DontUpdate;
            geyserController.ActivateAll(1.65f);
            
        }
    }

    public void EndState()
    {
    cart.OnCartStop -= EnableShooting;
     geyserController.OnAllGeysersEnd -= EnableMoving;
    }

    public void ResetState()
    {
        attacksPlayed = 0;
        miniState = Phase4State.CanMove;
    }
    private void EnableShooting() {
        miniState = Phase4State.CanShoot;
    }
    private void EnableMoving()
    {
        attacksPlayed++;
        miniState = Phase4State.CanMove;
    }
}
