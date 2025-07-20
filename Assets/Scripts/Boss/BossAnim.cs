using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    [SerializeField]
    private Animator head;
    [SerializeField] 
    private Animator body;
    [SerializeField]
    private Rigidbody2D rigidbody;
    private Vector3 direction;
    

    void Update()
    {
        direction = rigidbody.velocity;
         if (direction.x > 2.5f)
        {
            head.SetBool("IsRight", true);
            body.SetBool("IsLeftRight", true);
            body.SetFloat("X", 1f);
        }
        else if (direction.x < -2.5f)
        {
            head.SetBool("IsRight", true);
            body.SetBool("IsLeftRight", true);
            body.SetFloat("X", -1f);
        }
        else if (direction.y > 0)
        {
            head.SetBool("IsRight", false);
            body.SetBool("IsLeftRight", false);
            body.SetFloat("Y", 1f);
        }
        else
        {   head.SetBool("IsRight", false);
            body.SetBool("IsLeftRight", false);
            body.SetFloat("Y", -1f);
        }
    }
}
