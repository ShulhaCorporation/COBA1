using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;

    private Vector3 currentSpawnPoint;

    void Start(){
        var checkpoints = gameObject.GetComponentsInChildren<Checkpoint>();
        foreach (var checkpoint in checkpoints){
            checkpoint.OnCheckpointEntered+=OnCheckpointEntered;
        }
    }

    private void OnCheckpointEntered(Vector3 position, int id)
    {
        Debug.Log(position + "" + id);
        currentSpawnPoint = position;
    }

    public void Respawn(){
        playerTransform.position = currentSpawnPoint;
    }
}
