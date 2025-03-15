using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase5 : iState
{
    private BossStates bossStates;
    private GeyserController geyserController;
    private Cart cart;
    private bool isStopped = false;
    public Phase5(BossStates bossStates) {  
        this.bossStates = bossStates; 
    }
    public void StartState()
    {
        geyserController = bossStates.geyserController;
        cart = bossStates.cart;
        cart.OnCartStop += EnableMoving;
        cart.SetSpeed(3f);
        geyserController.ActivateAll(150.65f);
        isStopped = false;
        bossStates.delayer.OnDelayEnd += EnableMoving;
        bossStates.delayer.Wait(3f);
    }

    public void UpdateState()
    {   if(bossStates.timer.GetSeconds() < bossStates.phase5Ends)
        {
            //bossStates.Transition(bossStates.outro);
        }
       else if (isStopped)
        {
            isStopped = false;
            cart.MoveRandom(0f);
        }
    }

    public void EndState()
    {
      
    }

    public void ResetState()
    {
        isStopped = false;
    }
    public void EnableMoving()
    {
        isStopped = true;
    }
}
