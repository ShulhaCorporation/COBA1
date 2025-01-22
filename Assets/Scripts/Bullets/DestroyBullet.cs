using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField]
    private float particlesSpeed;
    private ParticleController particleController;
    public void SetController(ParticleController particleController)
    {
        this.particleController = particleController;
    }
     void OnCollisionEnter2D(Collision2D collision)
    {  //віддача при зіткненні частинок з об'єктом
        Vector3 knockback = collision.relativeVelocity.normalized * particlesSpeed;
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Destroy(0.1f, knockback));
        }
        else
        {
            StartCoroutine(Destroy(0f, knockback));
        }
    }
    IEnumerator Destroy(float delay, Vector3 knockback)
    {
        yield return new WaitForSeconds(delay); //затримка, бо по сові не встигає наноситися удар
        particleController.Place(transform.position, knockback);
        Destroy(gameObject);
    }
}
