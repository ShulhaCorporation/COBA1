using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum BatState{
    Normal,
    Immortal
}

public class TouchSpike : MonoBehaviour
{
    private LifeSystem lifeset;
    private Rigidbody2D rigidbody;
    private BatState state = BatState.Normal;
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
            HandleCollision(collision);
        }
    }

    private void HandleCollision(Collision2D collision)
    {
        if(state != BatState.Immortal)
        {
           // AudioSystem.instance.PlayEffect(onTouchClip);
            lifeset.AddHp(-1);
            anim.SetTrigger("TouchSpike");
            StartCoroutine(TriggerImmortal(2));
        }
        Transform otherTransform = collision.transform;

        Vector3 difference = otherTransform.position - transform.position;
        if(difference.magnitude < 5) //при з≥ткненн≥ з tilemap в≥дбуваЇтьс€ дуже сильна в≥ддача, бо transform далеко в≥д гравц€. ц€ перев≥рка в≥дс≥юЇ великий knockback
        {
            rigidbody.AddForce(difference * knockback);
        }
       

        
    }

    IEnumerator TriggerImmortal(float delay)
    {
        state = BatState.Immortal;
        yield return new WaitForSeconds(delay);
        state = BatState.Normal;
    }

    
}
