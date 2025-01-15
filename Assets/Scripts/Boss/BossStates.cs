using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStates : MonoBehaviour
{
    public Phase1 phase1;
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
    public float minDelay;
    [SerializeField]
    public float maxDelay;
    [SerializeField]
    public ShootController shootController;
    public float phase1Ends = 110f;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();  //навіщо окремий метод для ініціалізації, якщо він ніде не викликається? можна це прибрати і засунути логіку в Start()?
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
    public void Initialize()
    {
        phase1 = new Phase1(this);
        phase2 = new Phase2();
        currentState = phase1;
        currentState.StartState();
    }
    public void Transition(iState state)
    {
        currentState.EndState();
        currentState = state;
        currentState.StartState();
    }
}
