using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3 : iState
{   private BossStates bossStates;
    private GeyserController controller;
    private bool canShoot = true;
    private BoostSpawner spawner;
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
        spawner = bossStates.boostSpawner.GetComponent<BoostSpawner>();
        spawner.SetSpawnArea(new Vector3(109, 84.24f, 0), new Vector3(121.35f, 89.28f, 0));
    }

    public void UpdateState()
    {     if(bossStates.timer.GetSeconds() < bossStates.phase3Ends)
        {
            bossStates.Transition(bossStates.transition3);
            canShoot = false;
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
        if (controller != null)
        {
            controller.ResetGeysers();
        }
    }
}
