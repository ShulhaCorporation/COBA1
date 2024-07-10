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
    [SerializeField]
    private float jumpSpeed;
    private Vector3 direction;
    private Rigidbody2D rigidbody2D;
    private GameObject player;
    void Start(){
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        detector.OnGroundDetected += OnGroundDetected;
        Pdetector.OnplayerDetected += OnplayerDetected;
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        rigidbody2D.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnGroundDetected()
    {
        FlipSide();
    }
    private void OnplayerDetected(){
        direction = player.transform.position - transform.position;
        direction = direction.normalized;
        rigidbody2D.AddForce(direction * jumpSpeed);
    }

    private void FlipSide()
    {
        transform.Rotate(180,0,0);
    }

 
}
