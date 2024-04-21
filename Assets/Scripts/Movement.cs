using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float flightSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var moveX = Input.GetAxis("Horizontal");

        int moveX = 0;
        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1;
        }

        float moveY = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            moveY += 1;
        }

        rigidbody2D.velocity = new Vector3(moveX*speed, moveY* flightSpeed, 0);

    }
}