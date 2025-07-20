using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MiniState
{
    Fly,
    Shoot,
    Wait
}
public class Phase2 : iState
{
    private BossStates bossStates;
    private Rigidbody2D rigidbody;
    private ShootController shootController;
    private BoostSpawner heartBoostSpawner;
    private MiniState miniState = MiniState.Fly;
    private ShootCountdown countdown;
    private HeadAnim head;
    private float speed;
    public Phase2(BossStates bossStates)
    {
        this.bossStates = bossStates;
    }

    public void EndState()
    {
       rigidbody.velocity = Vector3.zero;
        bossStates.heartSpawner.SetActive(false);
    }

    public void StartState()
    {
      rigidbody = bossStates.GetComponent<Rigidbody2D>();
        head = bossStates.headAnim;
        countdown = bossStates.shootCountdown;
        speed = bossStates.speed2;
        bossStates.heartSpawner.SetActive(true);
        heartBoostSpawner = bossStates.heartSpawner.GetComponent<BoostSpawner>();
        heartBoostSpawner.PlaceBooster();
        shootController = bossStates.shootController;
        shootController.OnShootEnd += SwitchToFly;
        countdown.OnCountdownEnd += SwitchToShoot;
        SwitchToFly();
    }

    public void UpdateState()
    {
        if (bossStates.timer.GetSeconds() <= bossStates.phase2Ends)
        {
            bossStates.Transition(bossStates.transition2);
        }
        if (miniState == MiniState.Fly)
        {
            rigidbody.velocity = (bossStates.player.position - bossStates.transform.position).normalized * speed;
        }
        else if(miniState == MiniState.Shoot)
        {
            miniState = MiniState.Wait;
            rigidbody.velocity = Vector3.zero;
            shootController.Fire(0.5f, 0.501f,bossStates.player.position);
        }
    }
    private void SwitchToFly()
    {
        miniState = MiniState.Fly;
        countdown.StartCountdown(3);
    }
    private void SwitchToShoot()
    {
        head.OpenForSec(0.5f);
        miniState = MiniState.Shoot;
    }
    public void ResetState()
    {
        miniState = MiniState.Fly;
    }
}
