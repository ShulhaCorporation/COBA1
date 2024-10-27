using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FollowPlayerState : IState
{
    private Rigidbody2D bossRigidbody;
    private Transform bossTransform;
    private Transform playerTransform;

    private float speed;
    private readonly BossStateMachine bossStateMachine;

    public FollowPlayerState(Rigidbody2D bossRigidbody, Transform playerTransform, Transform bossTransform, float speed, BossStateMachine bossStateMachine)
    {
        this.bossRigidbody = bossRigidbody;
        this.playerTransform = playerTransform;
        this.bossTransform = bossTransform;
        this.speed = speed;
        this.bossStateMachine = bossStateMachine;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        Vector3 dir = bossTransform.position - playerTransform.position;

        bossRigidbody.velocity = dir.normalized * speed;

        if (Time.time > 10){
            bossStateMachine.TransitionTo(bossStateMachine.hidePlayerState);
        }
    }
}