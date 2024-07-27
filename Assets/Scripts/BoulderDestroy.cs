using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDestroy : MonoBehaviour
{
    private Animator anim;
  
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
          
            anim.SetTrigger("Destroy");
            StartCoroutine(Remove(1.0f));
            
        }
    }
    IEnumerator Remove(float delay)
    { 
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
