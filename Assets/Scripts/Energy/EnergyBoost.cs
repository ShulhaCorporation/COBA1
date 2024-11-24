using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBoost : MonoBehaviour
{
    [SerializeField]
    private float power;
    [SerializeField]
    private GameObject player;
    private EnergyCount energyCount;
    private void Start()
    {
        energyCount = player.GetComponent<EnergyCount>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TRIGGERED");
            energyCount.AddPower(power);
            Destroy(gameObject);
        }
    }
}
