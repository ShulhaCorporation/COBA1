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
    public void SetState(OwlState stateIndex)
    {
        state = stateIndex;
    }
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

    void OnTriggerStay2D(Collider2D collider) //для обробки рідких перешкод (гейзери)
    {
        if (collider.gameObject.tag == "Deadly")
        {
            isOnSpike = true;
            HandleCollision(collider);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Deadly")
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
    private void HandleCollision(Collider2D collider) //перегрузка для рідких тіл
    {
        if (state != OwlState.Immortal)
        {
            // AudioSystem.instance.PlayEffect(onTouchClip);
            lifeset.AddHp(-1);
            anim.SetTrigger("TouchSpike");
            StartCoroutine(TriggerImmortal(2));
            HandleKnockback(collider);
        }
      }

    private void HandleKnockback(Collision2D collision)
    {
        Transform otherTransform = collision.transform;

        difference = (otherTransform.position - transform.position).normalized;
            rigidbody.AddForce(difference * knockback);
    }
    private void HandleKnockback(Collider2D collider) //перегрузка для рідких тіл
    {
        Transform otherTransform = collider.transform;

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
