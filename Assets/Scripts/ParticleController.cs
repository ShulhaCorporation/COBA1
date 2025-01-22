using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> queue = new List<GameObject>();
    public void Place(Vector3 position, Vector3 force)
    {   ParticleSystem particleSystem = queue[0].GetComponent<ParticleSystem>();
        var velocity = particleSystem.velocityOverLifetime;
        velocity.x = new ParticleSystem.MinMaxCurve(force.x); //віддача при зіткненні частинок з об'єктом
        velocity.y = new ParticleSystem.MinMaxCurve(force.y);
        velocity.z = new ParticleSystem.MinMaxCurve(0f);
        queue[0].transform.position = position;
        queue[0].SetActive(true);
        particleSystem.Play();
        queue.Add(queue[0]);
        queue.RemoveAt(0);
    }
}
