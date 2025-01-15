using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Transform target;
    private Vector3 direction;
    protected Rigidbody2D rigidbody;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        direction = target.position - transform.position;
        direction.Normalize();
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        
        rigidbody.velocity = direction * speed * Time.deltaTime;
        AnotherBulletLogic();
    }
    protected abstract void AnotherBulletLogic();
}
