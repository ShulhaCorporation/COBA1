using System;
using UnityEngine;
using UnityEngine.UI;


public class VolumeChanger : MonoBehaviour{
    public event Action<float> OnVolumeChanged;
    [SerializeField]
    private Scrollbar volumeScrollbar;
    void Awake()
    {
        volumeScrollbar.value = SaveSystem.instance.gameData.musicVolume;
    }
    public void OnVolumeChange()
    {
        AudioSystem.instance.SetMusicVolume(volumeScrollbar.value);
        SaveSystem.instance.gameData.musicVolume = volumeScrollbar.value;
        SaveSystem.instance.Save();
    }
}