using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        rigidbody.velocity = Vector3.zero;
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
        bossStates.boostSpawner.SetActive(true);
        bossStates.pointDetector.OnBossPoint += ChangePoint;
      
    }

    public void UpdateState()
    {
        
       if(bossStates.timer.GetSeconds() <= bossStates.phase1Ends)
        {
            bossStates.Transition(bossStates.transition1);
        }
       Vector3 distance = keyframes[currentIndex] - bossStates.transform.position;
       
          
       
        rigidbody.velocity = distance.normalized * speed;
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
