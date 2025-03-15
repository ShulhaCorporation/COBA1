using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserController : MonoBehaviour
{
    [SerializeField]
    private List<GeyserSwitching> geysers;
    [SerializeField]
    private int activateAtOnce = 4;
    [SerializeField]
    private float shootLength = 1.65f; // 0.65 cekyHD D/\9 nonepeD)|(eHH9, 1 D/\9 BucTpi/\y
    [SerializeField]
    private float betweenShots = 0.5f;
    private List<GeyserSwitching> randomGeysers = new List<GeyserSwitching>();
    private List<GeyserSwitching> shuffleMemory = new List<GeyserSwitching>();
    public event Action OnRandomGeyserEnd;
    public event Action OnAllGeysersEnd;
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
    public void ResetGeysers()
    {
        StopAllCoroutines();
        foreach (var geyser in geysers)
        {
            geyser.InstantOff();
        }
        randomGeysers.Clear();
        shuffleMemory.Clear();
        foreach (var geyser in geysers)
        {
            randomGeysers.Add(geyser);
        }
        foreach (var geyser in geysers)
        {
            geyser.InstantOff();
        }
    }

    public void ActivateAll(float duration)
    {
        StartCoroutine(EnableAll(duration));
    }
    IEnumerator EnableAll(float duration)
    {
        foreach (var geyser in geysers)
        {
            geyser.Switch(true);
        }
        yield return new WaitForSeconds(duration);
        foreach (var geyser in geysers)
        {
            geyser.Switch(false);
        }
        OnAllGeysersEnd?.Invoke();
    }
}
