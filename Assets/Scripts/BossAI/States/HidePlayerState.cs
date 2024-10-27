using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HidePlayerState : IState
{
    private Rigidbody2D bossRigidbody;
    private Transform bossTransform;
    private Transform playerTransform;

    private float speed;

    public HidePlayerState(Rigidbody2D bossRigidbody, Transform playerTransform, Transform bossTransform, float speed)
    {
        this.bossRigidbody = bossRigidbody;
        this.playerTransform = playerTransform;
        this.bossTransform = bossTransform;
        this.speed = speed;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        Vector3 dir = playerTransform.position - bossTransform.position;

        bossRigidbody.velocity = dir.normalized * speed;
    }
}