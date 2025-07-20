using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public event Action OnShootEnd;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private ParticleController controller;
    [SerializeField]
    private Transform head;
    private bool delayAfterRespawn = true;
   public void Fire(float min, float max, Vector3 playerPos)
    {
        StartCoroutine(Shoot(min, max, playerPos));
    }
    IEnumerator Shoot(float min, float max, Vector3 playerPos)
    {      
        if (delayAfterRespawn)
        {
            yield return new WaitForSeconds(1.4f);
            delayAfterRespawn = false;
        }
        GameObject bulletObject = Instantiate(bullet, head.position, Quaternion.identity);
        Bullet bulletGO = bulletObject.GetComponent<Bullet>();
        bulletGO.SetTarget(playerPos);
        DestroyBullet destroy = bulletObject.GetComponent<DestroyBullet>();
        destroy.SetController(controller);
        yield return new WaitForSeconds(UnityEngine.Random.Range(min, max));
        OnShootEnd?.Invoke();

    }
    public void ResetDelayAfterRespawn()
    {
        delayAfterRespawn = true;
        StopAllCoroutines(); //виправляє баг, де після респавну приходить івент зі старої корутини і босс запускає декілька снарядів
    }
}
