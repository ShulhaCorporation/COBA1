using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance;

    public AudioSource musicSource;
    public AudioSource fxSource;

    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume){
        musicSource.volume = volume;
    }

    public float GetMusicVolume(){
        return musicSource.volume;
    }
    public void SetSFXVolume(float volume)
    {
        fxSource.volume = volume;
    }

    public float GetSFXVolume()
    {
        return fxSource.volume;
    }
    public void PlayMusic(AudioClip clip){
        musicSource.clip = clip; //зміна кліпу, тобто попередній звук припиняється
        musicSource.Play();
    }

    public void StopMusic(){
        musicSource.Stop();
    }

    public void PlayEffect(AudioClip clip){
        fxSource.PlayOneShot(clip); //грає звук один раз, дозволяє багато ефектів одночасно
    }
}
