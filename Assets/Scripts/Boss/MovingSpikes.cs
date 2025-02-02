using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingSpikes : AResetable
{ private Vector3 target;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;
    private Coroutine coroutine;
    void Start()
    {
        target = transform.position + new Vector3(0, 1.32f, 0);  
    }
    public void Move()
    {
       coroutine = StartCoroutine(MoveSpikes());
    }
    IEnumerator MoveSpikes()
    {
        while(transform.position.y < 81.6f)
        {
            rigidbody.velocity = Vector3.up * Time.deltaTime * speed;
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
        transform.localPosition = new Vector3(101.0356f, 81.95773f, -0.7997909f);
    }
}
