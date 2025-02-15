using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    private IBooster booster;
    [SerializeField]
    private BoosterTag gameObj; //o6xiDHuu w/\9x D/\9 cepia/\i3au,iii iHTepqpeuciB 
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
        if (gameObj.GetComponent<EnergyBoost>() != null)
        {
            booster = gameObj.GetComponent<EnergyBoost>();
        }
        else if(gameObj.GetComponent<LifeBoost>() != null)
        {
            booster = gameObj.GetComponent<LifeBoost>();
        }
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
        booster.SetPosition(spawnpoint);
        particles.transform.position = spawnpoint;
        booster.SetActive(true);
    }
}
