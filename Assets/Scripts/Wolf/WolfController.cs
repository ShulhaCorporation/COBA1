using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    [SerializeField]
    private GroundDetector detector;
     [SerializeField]
    private PlayerDetector Pdetector;
    [SerializeField]
    private float speed;

    private Rigidbody2D rigidbody2D;

    void Start(){
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        detector.OnGroundDetected += OnGroundDetected;
        Pdetector.OnplayerDetected += OnplayerDetected;
    }

    private void OnGroundDetected()
    {
        FlipSide();
    }
    private void OnplayerDetected(){
        Debug.Log("Bebra");
    }

    private void FlipSide()
    {
        transform.Rotate(180,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = transform.up * speed;
    }
}
