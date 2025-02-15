using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition1 : iState
{
    private BossStates bossStates;
    private Vector3 direction;
    private Rigidbody2D rigidbody;
    private bool canMove = true;
    private TransitionWorker1 transitionManager;
    
    public Transition1(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }
    public void EndState()
    {
       
    }

    public void StartState()
    {
      rigidbody = bossStates.GetComponent<Rigidbody2D>();
        transitionManager = bossStates.transitionManager;
        transitionManager.OnTransition1End += ToNextPhase;
    }

    public void UpdateState()
    {
        if (canMove) {
            direction = bossStates.centralBlock.position - bossStates.transform.position;
            rigidbody.velocity = direction.normalized * bossStates.transitionSpeed;
            if (direction.magnitude <= 4)
            { 
                canMove = false;
                rigidbody.velocity = Vector3.zero;
               transitionManager.StartScene();
            }
       
           
        }
    }
    private void ToNextPhase()
    {
        bossStates.Transition(bossStates.phase2);
        canMove = true;
    }
    public void ResetCanMove()
    {
        canMove = true;
    }
}
