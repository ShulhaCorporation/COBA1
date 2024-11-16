using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    [SerializeField]
    private float activeTime;
    [SerializeField]
    private float inactiveTime;
    [SerializeField] 
    private float setupDelay;
    [SerializeField]
    private GameObject steam;
    [SerializeField]
    private GeyserParticles geyserParticles;
    void Start()
    {
        StartCoroutine(SetupDelay());
     
    }
    public IEnumerator Shooting()
    {
        while (true)
        {   geyserParticles.StopParticles();
            steam.SetActive(false);
            yield return new WaitForSeconds(inactiveTime);
            steam.SetActive(true);
            geyserParticles.PlayParticles();
            yield return new WaitForSeconds(activeTime);
        }
    }
    public IEnumerator SetupDelay()
    {
        yield return new WaitForSeconds(setupDelay);
        StartCoroutine(Shooting());
    }
   
}
