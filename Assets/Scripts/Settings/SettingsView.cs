using System;
using UnityEngine;
using UnityEngine.UI;

interface ISettingsView
{
    public event Action<float> OnVolumeChanged;
}

public class SettingsView : MonoBehaviour, ISettingsView {
    public event Action<float> OnVolumeChanged;

    [SerializeField]
    private Scrollbar scrollbar;
    public void SetVolume(){
        OnVolumeChanged?.Invoke(scrollbar.value);
    }
}

public class SettingsViewWithAi : MonoBehaviour, ISettingsView {
    public event Action<float> OnVolumeChanged;

    [SerializeField]
    private Scrollbar scrollbar;
    public void SetVolume(){
        OnVolumeChanged?.Invoke(scrollbar.value);
    }
}