using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public event Action OnShootEnd;
    [SerializeField]
    private Bullet bullet;
   public void Fire(float min, float max, Vector3 playerPos)
    {
        StartCoroutine(Shoot(min, max, playerPos));
    }
    IEnumerator Shoot(float min, float max, Vector3 playerPos)
    {
        Bullet bulletGO = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        bulletGO.SetTarget(playerPos);
        yield return new WaitForSeconds(UnityEngine.Random.Range(min, max));
        OnShootEnd?.Invoke();
    }
}
