using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Rigidbody2D rigidbody;
    private float speed;
    private Phase4State miniState = Phase4State.CanMove;
    private Cart cart;
    private GeyserController geyserController;
    private BoostSpawner energySpawner;
    private BoostSpawner heartSpawner;
    private const int attacks = 5;
    private int attacksPlayed = 0;
    public Phase4(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }

    public void StartState()
    {
        rigidbody = bossStates.GetComponent<Rigidbody2D>();
        speed = bossStates.speed2;
        miniState = Phase4State.CanMove;
        cart = bossStates.cart;
        geyserController = bossStates.geyserController;
        attacksPlayed = 0;
        cart.OnCartStop += EnableShooting;
        geyserController.OnAllGeysersEnd += EnableMoving;
        energySpawner = bossStates.boostSpawner.GetComponent<BoostSpawner>();
        heartSpawner = bossStates.heartSpawner.GetComponent<BoostSpawner>();
        heartSpawner.gameObject.SetActive(true);
        heartSpawner.PlaceBooster();
        energySpawner.SetSpawnArea(new Vector3(108.96f, 87.28f, 0), new Vector3(120.45f, 89.89f, 0));
        heartSpawner.SetSpawnArea(new Vector3(108.96f, 87.28f, 0), new Vector3(120.45f, 89.89f, 0));
    }

    public void UpdateState()
    {    rigidbody.velocity = new Vector3(cart.transform.position.x - bossStates.transform.position.x ,0 , 0).normalized * speed;
        if (attacksPlayed >= attacks)
        {
            rigidbody.velocity = Vector3.zero;
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
        heartSpawner.gameObject.SetActive(false);
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
