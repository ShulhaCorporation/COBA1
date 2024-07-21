using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePrefab;

    [SerializeField]
    private float minSec;
    [SerializeField]
    private float maxSec;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCirclesCoroutine(minSec, maxSec));
    }

    IEnumerator SpawnCirclesCoroutine(float min, float max)
    { 
        while(true){
             //float delay = rnd.Next(min, max);
            float delay = Random.Range(min, max);
             
            yield return new WaitForSeconds(delay);
            Instantiate(circlePrefab, transform.position, Quaternion.identity);
        }
    }

}
