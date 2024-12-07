using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using Debug = UnityEngine.Debug;
enum State
{
    Wait,
    Attack
}
public class BatAngry : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 playerPosition;
    private int currentState = 0;
    [SerializeField]
    private float viewDistance;
    [SerializeField]
    private float prepareTime;
    [SerializeField]
    private float afterAttackTime;
    [SerializeField] 
    private float attackDuration;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float knockback;
    private Vector3 distanceToPlayer;
    private Rigidbody2D rigidbody;
    private Coroutine attack;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (attack != null && collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(attack);
            attack = null;
            rigidbody.velocity = distanceToPlayer.normalized * knockback;
            //анімація очікування
            StartCoroutine(AfterCollision(afterAttackTime));
        }
    }

    void Update()
    {
            if (currentState == (int)State.Wait)
            {
              
                Trace();
            }
            else
            {
              
                Attack();
                
            }
    }
    private void Trace()
    {   playerPosition = player.transform.position;
        distanceToPlayer = playerPosition - transform.position;
        if (distanceToPlayer.magnitude <= viewDistance)
        {
            currentState = (int)State.Attack;
        }
       
    }
    private void Attack()
    {  
        //тут буде анімація перед атакою
        attack = StartCoroutine(AttackProcess(prepareTime,afterAttackTime,attackDuration));
        currentState = (int)State.Wait;
       
    }
    IEnumerator AttackProcess(float prepareTime, float afterAttackTime, float attackDuration)
    {    
        yield return new WaitForSeconds(prepareTime);

        //анімація атаки
        rigidbody.velocity = distanceToPlayer.normalized * speed;
        yield return new WaitForSeconds(attackDuration);
        rigidbody.velocity = Vector3.zero;
        //анімація очікування
        yield return new WaitForSeconds(afterAttackTime);
    }
    IEnumerator AfterCollision (float afterAttackTime)
    {
        yield return new WaitForSeconds(afterAttackTime);
    }
}
