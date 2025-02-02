using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarDestruction : AResetable
{
    [SerializeField]
    private GameObject firstBlock;
    [SerializeField]
    private List<GameObject> blocks;
    [SerializeField]
    private GameObject particles; 
    [SerializeField]
    private GameObject firstParticles;
    [SerializeField]
    private float timeBetweenBlocks;
    private Coroutine coroutine;
    public void Destroy()
    {
       coroutine = StartCoroutine(DestroyPillar());
    }

   

    IEnumerator DestroyPillar()
    {
        firstBlock.SetActive(false);
        Instantiate(firstParticles, firstBlock.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenBlocks);
        foreach (var block in blocks)
        {
            block.SetActive(false);
            Instantiate(particles, block.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenBlocks);
        }
    }
    public override void ResetItem()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        firstBlock.SetActive(true);
        foreach (var block in blocks)
        {
            block.SetActive(true);
        }
    }
}
