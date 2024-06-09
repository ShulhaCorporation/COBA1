using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TouchSpike : MonoBehaviour
{
    private LifeSystem lifeset;
    private Rigidbody2D rigidbody;

    [SerializeField]
    private float knockback;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        lifeset = gameObject.GetComponent<LifeSystem>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Deadly")
        { 
            lifeset.AddHp(-1);
            Transform otherTransform = collision.transform;

            Vector3 differance = otherTransform.position - transform.position;
            rigidbody.AddForce(differance * knockback);
            
            anim.SetTrigger("TouchSpike");
        }
    }

    
}
