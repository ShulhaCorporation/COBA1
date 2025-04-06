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
    private float hitboxScaleY;
    [SerializeField] 
    private float hitboxSpeed;
    [SerializeField]
    private SteamHitbox hitbox;
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
            hitbox.Switch(hitboxScaleY, hitboxSpeed, false);
            yield return new WaitForSeconds(inactiveTime);
            hitbox.Switch(hitboxScaleY, hitboxSpeed, true);
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
