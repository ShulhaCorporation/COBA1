using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float flightSpeed;
    [SerializeField]
    private Animator anim;
    private PlayerInput playerInput;
    private bool canFly = true;
    private bool isFallingFast = false;
    private bool isSlowdown = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerInput =  GetComponent<PlayerInput>(); // для отримання компонентів
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //var moveX = Input.GetAxis("Horizontal");

        float moveX = 0;
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
            if (rigidbody2D.velocity.y < -0.1)
            {
                isFallingFast = true;
                anim.SetBool("FastDown", true);
            }
        }
         
        if (!isFallingFast && rigidbody2D.velocity.y < -0.7 && !isSlowdown)
        {
            anim.SetBool("SlowDown", true);
            isSlowdown = true;
        }
        if(isFallingFast  || rigidbody2D.velocity.y >= -0.7)
        {
            isSlowdown = false;
            anim.SetBool("SlowDown", false);
           
        }
        anim.SetFloat("moveX" , moveX);
        if (moveX != 0)
        {
            anim.SetFloat("lastX" , moveX);
        }

        if (!isFallingFast)
        {
            anim.SetBool("FastDown", false );
        }
        anim.SetFloat("moveY" , moveY);
        
        rigidbody2D.velocity = new Vector3(moveX * speed, moveY * flightSpeed, 0);
        isFallingFast = false;
        
    }
    public void SetCanFly(bool canFly)
    {
        this.canFly = canFly;
    }


}