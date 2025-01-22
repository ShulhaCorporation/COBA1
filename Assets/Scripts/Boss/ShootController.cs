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
   public void Fire(float min, float max, Vector3 playerPos)
    {
        StartCoroutine(Shoot(min, max, playerPos));
    }
    IEnumerator Shoot(float min, float max, Vector3 playerPos)
    {
        GameObject bulletObject = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Bullet bulletGO = bulletObject.GetComponent<Bullet>();
        bulletGO.SetTarget(playerPos);
        DestroyBullet destroy = bulletObject.GetComponent<DestroyBullet>();
        destroy.SetController(controller);
        yield return new WaitForSeconds(UnityEngine.Random.Range(min, max));
        OnShootEnd?.Invoke();
    }
}
