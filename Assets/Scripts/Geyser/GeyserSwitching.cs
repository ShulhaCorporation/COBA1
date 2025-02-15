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
    private float speed;
    [SerializeField]
    private GameObject warning;
  
    public void Switch(bool state)
    {
        if (state)
        {
            StopAllCoroutines();
            StartCoroutine(TurnOn());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TurnOff());
        }
    }
    IEnumerator TurnOn()
    {     warning.SetActive(true);
          yield return new WaitForSeconds(0.75f);
        warning.SetActive(false);
        while (transform.localScale.y < maxScale)
        {
            transform.localScale += new Vector3(0, 0.001f * speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
    IEnumerator TurnOff()
    {
        while(transform.localScale.y > 0)
        {
            transform.localScale -= new Vector3(0, 0.001f * speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = new Vector3(0.2f, 0, 1); //w,o6 box collider He HaHocuB yDapy rpaBu,I-0
        yield return null;
    }
    public void InstantOff()
    {
        StopAllCoroutines();
        warning.SetActive(false);
        transform.localScale = Vector3.zero;
    }
}
