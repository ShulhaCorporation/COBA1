using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class TransitionWorker1 : AResetable
{
    [SerializeField]
    private List<GameObject> warnings;
    [SerializeField]
    private PillarDestruction pillarDestruction;
    [SerializeField]
    private MovingSpikes spikes;
    [SerializeField]
    private List<GameObject> bats;
    private List<Vector3> batPositions = new List<Vector3>();
    public event Action OnTransition1End;
    private Coroutine coroutine;


    void Start()
    {
        foreach (GameObject obj in bats)
        {
            batPositions.Add(obj.transform.position);
        }
    }
    public void StartScene()
    {
        coroutine = StartCoroutine(SpawnBats());
    }
    IEnumerator SpawnBats()
    {    foreach (var warning in warnings)
        {
            warning.SetActive(true);
        }
        pillarDestruction.Destroy();
        yield return new WaitForSeconds(2f);
        foreach (var bat in bats)
        {
            bat.SetActive(true);
        }
        spikes.Move();
        foreach (var warning in warnings)
        {
            warning.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        OnTransition1End.Invoke();
    }
    public override void ResetItem()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        foreach (var warning in warnings)
        {
            warning.SetActive(false);
        }
        for (int i = 0; i < bats.Count; i++) {
            bats[i].transform.position = batPositions[i];
            bats[i].SetActive(false);
        }
        
    }
}
