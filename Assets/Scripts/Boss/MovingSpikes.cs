using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingSpikes : AResetable
{ 
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 resetPosition;
    private Coroutine coroutine;
 
    public void MoveUp(float goal, bool mode)
    {
        if (mode)
        {
            coroutine = StartCoroutine(MoveSpikesUp(goal));
        }
        else
        {
            coroutine = StartCoroutine(MoveSpikesDown(goal));
        }
    }
    IEnumerator MoveSpikesUp(float goal)
    {
        while(transform.position.y < goal)
        {
            rigidbody.velocity = Vector3.up * speed;
            yield return new WaitForEndOfFrame();
        }
        rigidbody.velocity = Vector3.zero;
    }
 
    IEnumerator MoveSpikesDown(float goal)
    {
        while (transform.position.y > goal)
        {
            rigidbody.velocity = Vector3.down * speed;
            yield return new WaitForEndOfFrame();
        }
        rigidbody.velocity = Vector3.zero;
    }

    public override void ResetItem()
    {   if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        rigidbody.velocity = Vector3.zero;
        transform.localPosition = resetPosition;
    }
}
