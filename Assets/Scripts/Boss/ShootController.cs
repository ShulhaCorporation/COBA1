using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public event Action OnShootEnd;
    [SerializeField]
    private GameObject bullet;
   public void Fire(float min, float max)
    {
        StartCoroutine(Shoot(min, max));
    }
    IEnumerator Shoot(float min, float max)
    {
        Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(UnityEngine.Random.Range(min, max));
        OnShootEnd?.Invoke();
    }
}
