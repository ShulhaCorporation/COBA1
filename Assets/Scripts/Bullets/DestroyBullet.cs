using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;
    [SerializeField]
    private float particlesSpeed;
    private ParticleSystem particleSystem;
     void OnCollisionEnter2D(Collision2D collision)
    {  //віддача при зіткненні частинок з об'єктом
        Vector3 knockback = collision.relativeVelocity.normalized * particlesSpeed;
        particleSystem = particles.GetComponent<ParticleSystem>();
        var velocity = particleSystem.velocityOverLifetime;
        velocity.x = new ParticleSystem.MinMaxCurve(knockback.x);
        velocity.y = new ParticleSystem.MinMaxCurve(knockback.y);
        velocity.z = new ParticleSystem.MinMaxCurve(0f);
        StartCoroutine(Destroy());   
    }
    IEnumerator Destroy()
    {
        
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
