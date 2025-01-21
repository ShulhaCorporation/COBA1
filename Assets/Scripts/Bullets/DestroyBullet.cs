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
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Destroy(0.1f));
        }
        else
        {
            StartCoroutine(Destroy(0f));
        }
    }
    IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay); //затримка, бо по сові не встигає наноситися удар
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
