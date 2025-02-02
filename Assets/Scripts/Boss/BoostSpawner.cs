using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField]
    private EnergyBoost booster;
    [SerializeField]
    private GameObject particles;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private Vector3 leftDown;
    [SerializeField]
    private Vector3 rightUp;
    void Start()
    {
        booster.OnBoosterActivation += PlaceBooster;
        StartCoroutine(Place(spawnInterval));
    }
    private void PlaceBooster()
    {
        StartCoroutine(Place(spawnInterval));
    }
    IEnumerator Place(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 spawnpoint = new Vector3(Random.Range(leftDown.x, rightUp.x), Random.Range(leftDown.y, rightUp.y), 0);
        booster.transform.position = spawnpoint;
        particles.transform.position = spawnpoint;
        booster.gameObject.SetActive(true);
    }
}
