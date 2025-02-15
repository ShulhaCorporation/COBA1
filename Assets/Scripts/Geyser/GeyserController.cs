using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserController : AResetable
{
    [SerializeField]
    private List<GeyserSwitching> geysers;
    [SerializeField]
    private int activateAtOnce = 4;
    [SerializeField]
    private float shootLength = 1.75f; // 0.75 cekyHD D/\9 nonepeD)|(eHH9, 1 D/\9 BucTpi/\y
    [SerializeField]
    private float betweenShots = 0.5f;
    private List<GeyserSwitching> randomGeysers = new List<GeyserSwitching>();
    private List<GeyserSwitching> shuffleMemory = new List<GeyserSwitching>();
    public event Action OnRandomGeyserEnd;
    void Start()
    {
        foreach (var geyser in geysers)
        {
            randomGeysers.Add(geyser);
        }
    }
    public void ActivateRandom()
    {
        Shuffle();
        for (int i = 0; i < activateAtOnce; i++)
        {
            randomGeysers[i].Switch(true);
        }
        StartCoroutine(DisableRandoms());
    }
    private void Shuffle()
    {
        int n = randomGeysers.Count;
        int element = 0;
        for (int i = 0; i < n; i++)
        {
            element = UnityEngine.Random.Range(0, randomGeysers.Count);
            shuffleMemory.Add(randomGeysers[element]);
            randomGeysers.RemoveAt(element);
        }
        foreach(var geyser in shuffleMemory)
        {
            randomGeysers.Add(geyser);
        }
        shuffleMemory.Clear();
    }
    IEnumerator DisableRandoms()
    {
        yield return new WaitForSeconds(shootLength);
        for (int i = 0; i < activateAtOnce; i++)
        {
            randomGeysers[i].Switch(false);
        }
        yield return new WaitForSeconds(betweenShots);
        OnRandomGeyserEnd?.Invoke();
    }
    public override void ResetItem()
    {
        StopAllCoroutines();
        foreach(var geyser in geysers)
        {
            geyser.InstantOff();
        }
        randomGeysers.Clear();
        shuffleMemory.Clear();
        foreach (var geyser in geysers)
        {
            randomGeysers.Add(geyser);
        }
    }
}
