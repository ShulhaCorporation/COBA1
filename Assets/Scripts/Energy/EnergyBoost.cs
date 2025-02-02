using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBoost : AResetable
{
    [SerializeField]
    private float power;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private ParticleSystem particles;
    private EnergyCount energyCount;
    public event Action OnBoosterActivation;
    private void Start()
    {
        energyCount = player.GetComponent<EnergyCount>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            energyCount.AddPower(power);
            particles.Play();
            OnBoosterActivation?.Invoke();
            gameObject.SetActive(false);
        }
    }
    public override void ResetItem()
    {
        gameObject.SetActive(true);
    }
}
