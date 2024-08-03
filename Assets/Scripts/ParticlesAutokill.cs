using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutokill : MonoBehaviour
{
    [SerializeField]
    private float time;
    void Start()
    {
        StartCoroutine(Delete(time));
    }

    IEnumerator Delete(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

