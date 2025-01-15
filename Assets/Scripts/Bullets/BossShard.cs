using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShard : Bullet
{
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected override void AnotherBulletLogic()
    {  
       rb.angularVelocity = rotationSpeed * Time.deltaTime; 
    }

   
}
