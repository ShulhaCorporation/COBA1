using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject deathScreen;
    private LifeSystem lifesystem;
    private Vector3 currentSpawnPoint;
    private EnergyCount energyCount;
    private int currentId = 0;
    void Start(){
        lifesystem = player.GetComponent<LifeSystem>();
        energyCount = player.GetComponent<EnergyCount>();
        var checkpoints = gameObject.GetComponentsInChildren<Checkpoint>();
        foreach (var checkpoint in checkpoints){
            checkpoint.OnCheckpointEntered+=OnCheckpointEntered;
        }
    }

    private void OnCheckpointEntered(Vector3 position, int id)
    {
        
        if (id > currentId)
        {
            Debug.Log(position + "" + id);
            currentSpawnPoint = position;
            currentId = id;
        }
    }

    public void Respawn(){
        playerTransform.position = currentSpawnPoint;
        lifesystem.AddHp(3);
        energyCount.power = 1f;
        player.SetActive(true);
        deathScreen.SetActive(false);
    }
}