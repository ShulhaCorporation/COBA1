using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStates : AResetable
{
    public BossIntro intro;
    public Phase1 phase1;
    public Transition1 transition1;
    public Phase2 phase2;
    public Transition2 transition2;
    public Phase3 phase3;
    public iState currentState;
    [SerializeField]
    public Timer timer;
    [SerializeField]
    public ShootController shootController;
    [SerializeField]
    private Vector3 respawnPoint;
    [SerializeField]
    public float reqAltitude;
    [Header("Фаза 1")]
    [SerializeField]
    public Transform centralBlock;
    [SerializeField]
    public PointDetector pointDetector;
    [SerializeField]
    public List<Vector3> keyframes;
    [SerializeField]
    public float minDelay; //вистріли
    [SerializeField]
    public float maxDelay; //вистріли
    [Header("Фаза 2")]
    [SerializeField]
    public TransitionWorker1 transitionManager;
    [SerializeField]
    public ShootCountdown shootCountdown;
    [SerializeField]
    public Transform player;
    [Header("Кажани")]
    [SerializeField]
    public BatController batHorizontal;
    [SerializeField]
    public BatController batVertical;
    [Header("Фаза 3")]
    [SerializeField] 
    public Vector3 tran2Keyframe;
    [SerializeField]
    public GeyserController geyserController;
    [Header("Спавнери")]
    [SerializeField]
    public GameObject boostSpawner;
    [SerializeField]
    public GameObject heartSpawner;
    [Header("Рухомі пастки")]
    [SerializeField]
    public  MovingSpikes movingSpikes;
    [SerializeField]
    public MovingSpikes movingGeysers;
    [Header("Час закінчення фаз")]
    [SerializeField]
    public float phase1Ends = 109;
    [SerializeField]
    public float phase2Ends = 97;
    [SerializeField]
    public float phase3Starts = 93;
    [SerializeField]
    public float phase3Ends = 86;
    [Header("Швидкості")]
    [SerializeField]
    public float speed1;
    [SerializeField]
    public float speed2;
    [SerializeField]
    public float transitionSpeed;
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
        phase2 = new Phase2(this);
        transition2 = new Transition2(this);
        phase3 = new Phase3(this);
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
        phase1.ResetState();
        transition1.ResetState();
        phase2.ResetState();
        transition2.ResetState();
        phase3.ResetState();
        shootController.ResetDelayAfterRespawn();
        
    }
}
