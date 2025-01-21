using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 target;
    private Vector3 direction;
    protected Rigidbody2D rigidbody;
    void Start()
    { 
        rigidbody = GetComponent<Rigidbody2D>();
        direction = target - transform.position;
        direction.Normalize();
    }

    
    void Update()
    {
        if (rigidbody) 
            rigidbody.velocity = direction * speed * Time.deltaTime;
        AnotherBulletLogic();
    }
    protected abstract void AnotherBulletLogic();

    public void SetTarget(Vector3 playerPos)
    {
        target = playerPos;
    }
}
