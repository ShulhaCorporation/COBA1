using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Phase1 : iState
{ 
    private BossStates bossStates;
    private Rigidbody2D rigidbody;
    private List<Vector3> keyframes;
    private int currentIndex = 0;
    private bool rotatesClockwise = true;
    private float speed;
    private bool canShoot = true;
    private float minDelay;
    private float maxDelay;
    private ShootController shootController;
    public Phase1(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }
    private void ResetCanShoot()
    {
        canShoot = true;
        
    }

    public void EndState()
    {
        Debug.Log("phase 1 ended");
    }

    public void StartState()
    {
        rigidbody = bossStates.gameObject.GetComponent<Rigidbody2D>();
        keyframes = bossStates.keyframes;
        speed = bossStates.speed1;
        minDelay = bossStates.minDelay;
        maxDelay = bossStates.maxDelay;
        shootController = bossStates.shootController;
        shootController.OnShootEnd += ResetCanShoot;
    }

    public void UpdateState()
    {
        
       if(bossStates.timer.GetSeconds() <= bossStates.phase1Ends)
        {
            bossStates.Transition(bossStates.phase2);
        }
       Vector3 distance =   keyframes[currentIndex] - bossStates.transform.position;
        if(distance.magnitude <= 0.05f)
        {
            ChangePoint();
        }
        rigidbody.velocity = distance.normalized * speed * Time.deltaTime;
        if (canShoot)
        {
            canShoot = false;
            shootController.Fire(minDelay, maxDelay, bossStates.player.position); //корутину не можна викликати без Monobehaviour, тому для цього є окремий клас
        }

    }
    
    private void ChangePoint()
    {
       if(Random.Range(0,3) == 0)
        {
            rotatesClockwise = !rotatesClockwise;
        }

        if (rotatesClockwise)
        { currentIndex++; }
        else
        { currentIndex--; }

        if (currentIndex >= keyframes.Count)
        { currentIndex = 0; }
        else if (currentIndex < 0)
        {
            currentIndex = keyframes.Count - 1;
        }
        
    }
}

public class Phase2 : iState
{
    public void EndState()
    {

    }

    public void StartState()
    {

    }

    public void UpdateState()
    {

    }
}