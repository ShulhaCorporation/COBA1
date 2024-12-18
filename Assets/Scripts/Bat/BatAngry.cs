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
    private State currentState = State.Wait;
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
    private bool dontAttack = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
  /*  void OnCollisionEnter2D(Collision2D collision)
    {   
        if (attack != null && collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(attack);
            attack = null;
            rigidbody.velocity = distanceToPlayer.normalized * knockback;
            //анімація очікування
            StartCoroutine(AfterCollision(afterAttackTime));
        }
    }*/

    void Update()
    {
            if (currentState == State.Wait)
            {
              
                Trace();
            }
            else if(!dontAttack)
            {
              
                Attack();
                
            }
    }
    private void Trace()
    {   playerPosition = player.transform.position;
        distanceToPlayer = playerPosition - transform.position;
        if (distanceToPlayer.magnitude <= viewDistance)
        {
            Debug.Log("detected");
            currentState = State.Attack;
        }
       
    }
    private void Attack()
    {    dontAttack = true;
        //тут буде анімація перед атакою
        attack = StartCoroutine(AttackProcess(prepareTime,afterAttackTime,attackDuration));
    
       
    }
    IEnumerator AttackProcess(float prepareTime, float afterAttackTime, float attackDuration)
    {    
        yield return new WaitForSeconds(prepareTime);

        //анімація атаки
        rigidbody.velocity = distanceToPlayer.normalized * speed;
        Debug.Log("attack");
        yield return new WaitForSeconds(attackDuration);
        rigidbody.velocity = Vector3.zero;
        Debug.Log("stop");
        //анімація очікування
        yield return new WaitForSeconds(afterAttackTime);
        Debug.Log("tracing");
        dontAttack = false;
        currentState = State.Wait;
    }
    IEnumerator AfterCollision (float afterAttackTime)
    {
        yield return new WaitForSeconds(afterAttackTime);
    }
}
