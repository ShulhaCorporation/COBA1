using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOutro : iState
{
    private BossStates bossStates;
    private Rigidbody2D rigidbody;
    private bool canUpdate = true;
    public BossOutro( BossStates bossStates)
    {
        this.bossStates = bossStates;
    }
    public void StartState()
    {
        canUpdate = true;
        rigidbody = bossStates.GetComponent<Rigidbody2D>();
        bossStates.door.OnDoorOpen += FlyAway;
    }

    public void UpdateState()
    {
        if (bossStates.timer.GetSeconds() <= 0 && canUpdate)
        {
            rigidbody.velocity = Vector3.zero;
            canUpdate = false;
            bossStates.door.Open();
        }
        else if (canUpdate){
            rigidbody.velocity = (bossStates.player.position - bossStates.transform.position).normalized * bossStates.speed1;  
        }
    }

    public void EndState()
    {
        
    }

    public void ResetState()
    {
        
    }
    private void FlyAway()
    {
        Vector3 direction = (bossStates.lastPoint - bossStates.transform.position).normalized;
        rigidbody.velocity = direction * bossStates.speed1;
    }
}
