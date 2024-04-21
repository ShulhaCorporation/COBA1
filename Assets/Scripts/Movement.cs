using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
   public float speed = 500f;
    [SerializeField]
    public float flightSpeed = 1f;
    Rigidbody2D sila;
    void Start()
    {
        sila = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime ;
        if(Input.GetKey(KeyCode.Space))
        transform.position += new Vector3(0, 3, 0) * flightSpeed * Time.deltaTime;

    }
}
