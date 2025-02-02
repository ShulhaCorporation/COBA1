using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStates : AResetable
{
    public BossIntro intro;
    public Phase1 phase1;
    public Transition1 transition1;
    public Phase2 phase2;
    public iState currentState;
    [SerializeField]
    public Transform centralBlock;
    [SerializeField]
    public Timer timer;
    [SerializeField]
    public List<Vector3> keyframes;
    [SerializeField]
    public float speed1; 
    [SerializeField]
    public float minDelay; //вистріли
    [SerializeField]
    public float maxDelay; //вистріли
    [SerializeField]
    public ShootController shootController;
    [SerializeField]
    public float reqAltitude;
    [SerializeField]
    private Vector3 respawnPoint;
    [SerializeField]
    public Transform player;
    [SerializeField]
    public GameObject boostSpawner;
    [SerializeField]
    public float transitionSpeed;
    [SerializeField]
    public TransitionWorker1 transitionManager;
    [SerializeField]
    public PointDetector pointDetector;
    public float phase1Ends = 110f;
    // Start is called before the first frame update
    void Start()
    {
        Initialize(); 
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
    public void Initialize()
    {
        intro = new BossIntro(this);
        phase1 = new Phase1(this);
        transition1 = new Transition1(this);
        phase2 = new Phase2();
        currentState = intro;
        currentState.StartState();
    }
    public void Transition(iState state)
    {
        currentState.EndState();
        currentState = state;
        currentState.StartState();
    }
    public override void ResetItem()
    {
        currentState = phase1;
        transform.position = respawnPoint;
    }
}
