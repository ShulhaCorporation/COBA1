using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
   private float speed = 5f;
    [SerializeField]
    private float flightSpeed = 10f;
    Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        float moveX = 0;
        if (Input.GetKey(KeyCode.D)){
            moveX += 1;
        }
        if (Input.GetKey(KeyCode.A)){
            moveX -= 1;
        }

        float moveY = 0;
        if(Input.GetKey(KeyCode.Space)){
             moveY += 1;
            }

        rigidbody.velocity = new Vector3(moveX * speed, moveY * flightSpeed,0); 
    }
}
