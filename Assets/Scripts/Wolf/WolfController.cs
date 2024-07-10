using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WolfState{
    Normal,
    Immortal
}

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
    [SerializeField]
    private GameObject player;
    private bool isJumping = false;

    void Start(){
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        detector.OnGroundDetected += OnGroundDetected;
        Pdetector.OnplayerDetected += OnplayerDetected;
       
    }
    void Update()
    {
        Vector3 movement = transform.right * speed;
        if (isJumping) movement = movement + direction * jumpSpeed;
        rigidbody2D.velocity = movement ;
    }

    private void OnGroundDetected()
    {
        FlipSide();
    }
    private void OnplayerDetected(){
        
        direction = player.transform.position - transform.position;
        direction = direction.normalized;
        StartCoroutine(Jump(0.5f));

    }

    private void FlipSide()
    {
        transform.Rotate(0,180,0);
      
    }

    IEnumerator Jump(float delay)
    {
        isJumping = true;
        yield return new WaitForSeconds(delay);
        isJumping = false;
    }

 
}
