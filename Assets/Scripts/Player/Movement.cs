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

    private PlayerInput playerInput;
    private bool canFly = true;
    // Start is called before the first frame update
    void Start()
    {
        playerInput =  GetComponent<PlayerInput>(); // для отримання компонентів
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var moveX = Input.GetAxis("Horizontal");

        int moveX = 0;
        if (playerInput.IsRightPressed)
        {
            moveX += 1;
        }
        if (playerInput.IsLeftPressed)
        {
            moveX -= 1;
        }

        float moveY = 0;

        if (playerInput.IsFlyPressed && canFly)
        {
            moveY += 1;
        }
       
        if (playerInput.IsDownPressed) //різке падіння на кнопку s
        { moveY -= 1;
            
        }
        
            rigidbody2D.velocity = new Vector3(moveX * speed, moveY * flightSpeed, 0);
        

    }
    public void SetCanFly(bool canFly)
    {
        this.canFly = canFly;
    }
}