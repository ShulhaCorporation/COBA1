using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamHitbox : MonoBehaviour
{
  public void Switch(float scaleY, float speed, bool mode)
    {
        StopAllCoroutines();
        if (mode)
        {
            StartCoroutine(On(scaleY, speed));
        }
        else
        {
            StartCoroutine(Off(speed));
        }
    }
    IEnumerator On(float maxScale, float speed)
    {
        while (transform.localScale.y < maxScale)
        {
            transform.localScale += new Vector3(0, 0.001f * speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Off(float speed)
    {
        while (transform.localScale.y > 0)
        {
            transform.localScale -= new Vector3(0, 0.001f * speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}