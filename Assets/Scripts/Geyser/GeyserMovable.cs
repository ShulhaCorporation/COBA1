using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserMovable : MonoBehaviour
{
   
    [SerializeField]
    private Vector3 goalScale;
    [SerializeField]
    private float risingTime;
    [SerializeField]
    private float delay;
    [SerializeField]
    private float startDelay;
    private float iterationTime;
    private Vector3 startScale;
    private bool cycleWorks = true;
    void Start()
    {
        startScale = transform.localScale;
       iterationTime = risingTime / ((transform.localScale.y - goalScale.y) / 0.001f);
        StartCoroutine(Offset());
    }
     void Update()
    {
        if (!cycleWorks)
        {
            StartCoroutine(Cycle());
        }
    }
    IEnumerator Cycle()
    {
        cycleWorks = true;
       
        while (transform.localScale.y > goalScale.y)
        {
            transform.localScale -= new Vector3(0f,0.001f,0f);
            yield return new WaitForSeconds(iterationTime);
        }
        yield return new WaitForSeconds(delay);

        while (transform.localScale.y < startScale.y)
        {
            transform.localScale += new Vector3(0f, 0.001f, 0f);
            yield return new WaitForSeconds(iterationTime);
        }
        yield return new WaitForSeconds(delay);
        cycleWorks = false;
    }
    IEnumerator Offset()
    {
        yield return new WaitForSeconds(startDelay);
        cycleWorks = false;
    }
}
