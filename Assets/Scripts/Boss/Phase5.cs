using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase5 : iState
{
    private BossStates bossStates;
    private GeyserController geyserController;
    private MovingSpikes movingGeysers;
    private Cart cart;
    private bool isStopped = false;
    public Phase5(BossStates bossStates) {  
        this.bossStates = bossStates; 
    }
    public void StartState()
    {
        geyserController = bossStates.geyserController;
        movingGeysers = geyserController.gameObject.GetComponent<MovingSpikes>();
        cart = bossStates.cart;
        cart.OnCartStop += EnableMoving;
        cart.SetSpeed(2.4f);
        geyserController.ActivateAll(10f);
        isStopped = false;
        bossStates.delayer.OnDelayEnd += EnableMoving;
        bossStates.delayer.Wait(3f);
    }

    public void UpdateState()
    {   if(bossStates.timer.GetSeconds() < bossStates.phase5Ends)
        {
            bossStates.Transition(bossStates.outro);
        }
       else if (isStopped)
        {
            isStopped = false;
            cart.MoveRandom(0f);
        }
    }

    public void EndState()
    {
      bossStates.delayer.OnDelayEnd -= EnableMoving;
        cart.MoveTo(new Vector3(124.00f, 86.38f , 0));
        movingGeysers.MoveUp(80.6f, false);
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
