using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : AResetable
{
    [SerializeField]
    private float leftX; //109.02f
    [SerializeField] 
    private float rightX; //120.79f
    [SerializeField]
    private float defaultX; //124.00f
    [SerializeField]
    private float minimumDistance; //4.00f
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject banner;
    private float defaultSpeed;
    public event Action OnCartStop;
    void Start()
    {
        defaultSpeed = speed;  
    }
    public void MoveRandom(float eventDelay)
    {
        float pointX;
        do
        {
             pointX = UnityEngine.Random.Range(leftX, rightX);
        }
        while (Mathf.Abs(pointX - transform.position.x) < minimumDistance);

        Vector3 direction = new Vector3(pointX - transform.position.x, 0, 0).normalized;
        StartCoroutine(Move(direction, pointX, eventDelay));
    }
    IEnumerator Move(Vector3 direction, float pointX, float eventDelay)
    {
        animator.SetBool("moving", true);
      while(Mathf.Abs(pointX - transform.position.x) > 0.2f)
        {
            rigidbody.velocity = direction * speed;
            yield return new WaitForEndOfFrame();
        }
      rigidbody.velocity = Vector3.zero;
        animator.SetBool("moving", false);
        yield return new WaitForSeconds(eventDelay);
        OnCartStop?.Invoke();
    }
    public void Setup()
    {
        
        float centerPoint = (leftX + rightX) / 2;
        StartCoroutine(Move(Vector3.left, centerPoint, 0.4f));
        StartCoroutine(ShowBanner());
    }
    IEnumerator ShowBanner()
    {
        banner.SetActive(true);
        yield return new WaitForSeconds(4f);
        banner.SetActive(false);
    }
    public override void ResetItem()
    {
        StopAllCoroutines();
        banner.SetActive(false);
        animator.SetBool("moving", false);
        transform.position = new Vector3(defaultX, transform.position.y, 0);
        speed = defaultSpeed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
