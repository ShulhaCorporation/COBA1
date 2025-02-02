using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class BatAnim : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 direct;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
      direct = rb.velocity;
        if (direct.x > 0.1f)
        {
            anim.SetBool("IsUpDown", false);
            anim.SetFloat("direction", 1);
        }
        else if (direct.x < -0.1f)
        {
            anim.SetBool("IsUpDown", false);
            anim.SetFloat("direction", -1);
        }
        else if (direct.y > 0)
        {
            anim.SetBool("IsUpDown", true);
            anim.SetFloat("YForce", 1f);
        }
        else
        {
            anim.SetBool("IsUpDown", true);
            anim.SetFloat("YForce", -1f);
        }
    }
}
