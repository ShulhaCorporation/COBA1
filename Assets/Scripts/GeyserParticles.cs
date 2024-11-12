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
        
       
    }

 
   public void PlayParticles()
    {
        particles.SetActive(true);
        Debug.Log(particleSystem.isPlaying);
        particleSystem.Play();
    }
    public void StopParticles()
    {
        particles.SetActive(true);
        Debug.Log(particleSystem.isPlaying);
        particleSystem.Stop();
    }
}
