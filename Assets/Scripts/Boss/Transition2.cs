using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2 : iState
{
    private BossStates bossStates;
    private Rigidbody2D rigidbody;
    private bool canMove = true;
    private List<Vector3> batHorPoints= new List<Vector3>()
    {
        new Vector3(144, 87.11f, 0)
    };
    private List<Vector3> batVertPoints = new List<Vector3>()
    {
        new Vector3(114.81f, 99, 0)
    };
    private Vector3 direction;
    public Transition2(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }

    public void EndState()
    {
        
    }

    public void StartState()
    {
       bossStates.batHorizontal.ChangePointList(batHorPoints);
        bossStates.batVertical.ChangePointList(batVertPoints);
        direction = bossStates.tran2Keyframe - bossStates.transform.position;
        direction = direction.normalized;
        rigidbody = bossStates.GetComponent<Rigidbody2D>();
    }

    public void UpdateState()
    {      if (bossStates.timer.GetSeconds() <= bossStates.phase3Starts)
        {
            bossStates.Transition(bossStates.phase3);
        }
        if (canMove)
        {
            rigidbody.velocity = direction * bossStates.speed1;
            if(Vector3.Distance(bossStates.transform.position, bossStates.tran2Keyframe) < 0.2){
                canMove = false;
                rigidbody.velocity = Vector3.zero;
                bossStates.movingGeysers.MoveUp(82.85f, true);
                bossStates.movingSpikes.MoveUp(80.06f, false);
            }
        }
    }

}
