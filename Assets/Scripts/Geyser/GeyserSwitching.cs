using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GeyserSwitching : MonoBehaviour
{
    [SerializeField]
    private float maxScale = 0.7f;
    [SerializeField]
    private float cartScale = 0.28f;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private ParticleSystem particles;
    private bool touchingCart = false;
    private bool isTurningOff = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cart"))
        {
           
            touchingCart = true;
            transform.localScale = new Vector3(0.2f, cartScale, 0);
            
        }
    }
     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cart"))
        {
            
            touchingCart = false;
         
            if (!isTurningOff)
            { 
                StartCoroutine(TurnOn(false));
           
            }
        }  
    }
    public void Switch(bool state)
    {
        if (state)
        {
            isTurningOff = false;
            StopAllCoroutines();
            StartCoroutine(TurnOn(true));
        }
        else
        {
            isTurningOff = true;
            StopAllCoroutines();
            StartCoroutine(TurnOff());
        }
    }
    IEnumerator TurnOn(bool withWarning)
    {
        if (withWarning)
        {
            warning.SetActive(true);
            yield return new WaitForSeconds(0.65f);
            warning.SetActive(false);
        }
        particles.gameObject.SetActive(true);
        particles.Play();
        while (transform.localScale.y < maxScale)
        {   if (!touchingCart)
            {   
                transform.localScale += new Vector3(0, 0.001f * speed * Time.deltaTime, 0);
            }
           
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
    IEnumerator TurnOff()
    {    particles.Stop();
        while(transform.localScale.y > 0)
        {
            transform.localScale -= new Vector3(0, 0.001f * speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        particles.gameObject.SetActive(false);
        transform.localScale = new Vector3(0.2f, 0, 1); //w,o6 box collider He HaHocuB yDapy rpaBu,I-0
        isTurningOff = false;
       
        yield return null;
    }
    public void InstantOff()
    {
        StopAllCoroutines();
        particles.Stop();
        particles.Clear();
        warning.SetActive(false);
        isTurningOff = false;
        touchingCart = false;
        transform.localScale = new Vector3(0.2f, 0, 0);
    }
    public bool GetInfo()
    {
        return isTurningOff;
    }
}
