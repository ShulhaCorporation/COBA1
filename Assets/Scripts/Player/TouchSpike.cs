using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum OwlState{
    Normal,
    Immortal
}


public class TouchSpike : MonoBehaviour
{   private bool isOnSpike;
    private Vector3 difference;
    private LifeSystem lifeset;
    private Rigidbody2D rigidbody;
    private OwlState state = OwlState.Normal;
    [SerializeField]
    private float knockback;

    [SerializeField]
    private AudioClip onTouchClip;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        lifeset = gameObject.GetComponent<LifeSystem>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Deadly")
        {
            isOnSpike = true;
            HandleCollision(collision);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            isOnSpike = false;
        }
    }

    private void HandleCollision(Collision2D collision)
    {
        if (state != OwlState.Immortal)
        {
            // AudioSystem.instance.PlayEffect(onTouchClip);
            lifeset.AddHp(-1);
            anim.SetTrigger("TouchSpike");
            StartCoroutine(TriggerImmortal(2));
            HandleKnockback(collision);
        }
       


    }

    private void HandleKnockback(Collision2D collision)
    {
        Transform otherTransform = collision.transform;

        difference = (otherTransform.position - transform.position).normalized;
            rigidbody.AddForce(difference * knockback);
    }

    IEnumerator TriggerImmortal(float delay)
    {
        state = OwlState.Immortal;
        yield return new WaitForSeconds(delay);
        if (isOnSpike)
        {
            rigidbody.AddForce(difference * knockback);
        }
        state = OwlState.Normal;
    }

    
}
