using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject deathScreen;
    [SerializeField]
    private List<GameObject> hearts;
    [SerializeField]
    private TriggerBreakable triggerBreakable;
    [SerializeField]
    private BossStates boss;
    private LifeSystem lifesystem;
    private TouchSpike touchSpike;
    private Vector3 currentSpawnPoint;
    private EnergyCount energyCount;
    private int currentId = 0;
    private List<AResetable> currentResetables;

    void Start(){
        lifesystem = player.GetComponent<LifeSystem>();
        energyCount = player.GetComponent<EnergyCount>();
        touchSpike = player.GetComponent<TouchSpike>();
        var checkpoints = gameObject.GetComponentsInChildren<Checkpoint>();
        foreach (var checkpoint in checkpoints){
            checkpoint.OnCheckpointEntered+=OnCheckpointEntered;
        }
    }

    private void OnCheckpointEntered(Vector3 position, int id, List<AResetable> resetables)
    {
        
        if (id > currentId)
        {
            
            currentSpawnPoint = position;
            currentId = id;
            currentResetables = resetables;
        }
    }

    public void Respawn(){
        player.SetActive(true);
        deathScreen.SetActive(false);
        playerTransform.position = currentSpawnPoint;
        lifesystem.SetHp(3);
        energyCount.power = 1f;

        foreach (var heart in hearts)
        {
            HpView hpView = heart.GetComponent<HpView>();
            hpView.Reset();
        }

        foreach (var resetable in currentResetables)
        {
            resetable.ResetItem();
        }
        
       
        touchSpike.SetState(OwlState.Normal);
    }
}
