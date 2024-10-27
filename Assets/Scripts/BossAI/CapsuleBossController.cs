using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBossController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bossRigidbody;
    public Transform bossTranform;
    public Transform playerTransform;
    public float speed;
    BossStateMachine bossStateMachine;
    void Awake()
    {
        bossStateMachine = new BossStateMachine(bossRigidbody, playerTransform, bossTranform, speed);
    }
    // Start is called before the first frame update
    void Start()
    {
        bossStateMachine.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        bossStateMachine.Update();
    }
}
