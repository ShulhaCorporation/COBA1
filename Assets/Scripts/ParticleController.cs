using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> queue = new List<ParticleSystem>();
    public void Place(Vector3 position, Vector3 force)
    {   
        var velocity = queue[0].velocityOverLifetime;
        velocity.x = new ParticleSystem.MinMaxCurve(force.x); //������ ��� �������� �������� � ��'�����
        velocity.y = new ParticleSystem.MinMaxCurve(force.y);
        velocity.z = new ParticleSystem.MinMaxCurve(0f);
        queue[0].transform.position = position;
        queue[0].gameObject.SetActive(true);
        queue[0].Play();
        queue.Add(queue[0]);
        queue.RemoveAt(0);
    }
}
