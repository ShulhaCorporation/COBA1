using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoulders : MonoBehaviour
{
    [SerializeField]
    private GameObject boulder;
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;
    void Start()
    {
        StartCoroutine(Spawn(min, max));
    }
    private IEnumerator Spawn(float min, float max)
    {
        while (true) {
            yield return new WaitForSeconds(Random.Range(min, max));
            Instantiate(boulder, transform.position, Quaternion.identity);
        }
    }
}
