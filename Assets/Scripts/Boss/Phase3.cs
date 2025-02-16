using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3 : iState
{   private BossStates bossStates;
    private GeyserController controller;
    private bool canShoot = true;
    public Phase3(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }

    public void EndState()
    {
        
    }

    public void StartState()
    {
        controller = bossStates.geyserController;
        controller.OnRandomGeyserEnd += EnableShooting;
        canShoot = true;
        
    }

    public void UpdateState()
    {     if(bossStates.timer.GetSeconds() < bossStates.phase2Ends)
        {
            //bossStates.Transition(bossStates.phase4);
        }
        if (canShoot)
        {
            canShoot = false;
            controller.ActivateRandom();
        }
    }
    private void EnableShooting()
    {
        canShoot = true;
    }
    public void ResetState()
    {
        canShoot = true;
        controller.ResetGeysers();
    }
}
