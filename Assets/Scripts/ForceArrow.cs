using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ForceArrow : MonoBehaviour
{
    [SerializeField]
    private float power;
    [SerializeField] 
    private float activeTime;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Movement movement;
    private float direction;
    private Vector2 force;
    void Start()
    {
        direction = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        force = new Vector2(Mathf.Sin(direction) * -1, Mathf.Cos(direction)) * power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Push());

        }
    }
    IEnumerator Push()
    {
        movement.EnableDashing(true);
        rigidbody.velocity = force;
        yield return new WaitForSeconds(activeTime);
        movement.EnableDashing(false);
    }
}
