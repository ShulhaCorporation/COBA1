using UnityEngine;

public class BossStateMachine{

    private IState currentState;

    public FollowPlayerState followPlayerState;
    public HidePlayerState hidePlayerState;


    public BossStateMachine(Rigidbody2D bossRigidbody, Transform playerTransform, Transform bossTransform, float speed)
    {
        this.followPlayerState = new FollowPlayerState(bossRigidbody,
                                                       bossTransform,
                                                       playerTransform,
                                                       speed);
        
        this.hidePlayerState = new HidePlayerState(bossRigidbody,
                                                       bossTransform,
                                                       playerTransform,
                                                       speed);

    }

    public void Initialize(){
        followPlayerState.Enter();
        currentState = followPlayerState;
    }

    public void Update(){
        if (currentState != null){
            currentState.Update();
        }
    }

    public void TransitionTo(IState nextState)
        {
            currentState.Exit();
            currentState = nextState;
            nextState.Enter();
        }
}