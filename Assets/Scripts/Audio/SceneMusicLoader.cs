using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicLoader : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    void Awake(){
        AudioSystem.instance.PlayMusic(audioClip);
    }
}
