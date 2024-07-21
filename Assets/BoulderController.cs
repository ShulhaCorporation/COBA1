using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderController : MonoBehaviour
{
    [SerializeField]
    private Animator boulderAnim;
    [SerializeField]
    private GameObject boulderBurst;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Destroy"){
            boulderAnim.SetTrigger("Burst");
            HandleBurst();
        }
    }

    private void HandleBurst()
    {

        Instantiate(boulderBurst,transform.position, Quaternion.identity);
    }

    private void HandleDestroy()
    {
        Destroy(gameObject);
    }
}
