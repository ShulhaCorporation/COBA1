using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDestroy : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private GameObject particlesPrefab;

    [SerializeField]
    private float offset; 
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
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
        Instantiate(particlesPrefab,new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
        //particlesPoint.Play();
        Destroy(gameObject);
        
    }
}
