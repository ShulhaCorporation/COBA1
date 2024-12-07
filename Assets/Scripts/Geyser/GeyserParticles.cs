using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserParticles : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;
    private ParticleSystem particleSystem;
    void Start()
    {   
        particleSystem = particles.GetComponent<ParticleSystem>();
        particleSystem.Stop();
       
    }

 
   public void PlayParticles()
    {
        particles.SetActive(true);
        particleSystem.Play();
    }
    public void StopParticles()
    {
        particles.SetActive(true);

        particleSystem.Stop();
    }
}
