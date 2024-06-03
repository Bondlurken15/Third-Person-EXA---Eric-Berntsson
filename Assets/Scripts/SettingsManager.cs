using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioSource musicPlayer;
    
    [SerializeField] UnityEngine.UI.Scrollbar sensitivitySlider;
    [SerializeField] UnityEngine.UI.Scrollbar musicVolumeSlider;
    [SerializeField] SettingsValues mySettingsObj;

    void Update()
    {
        mySettingsObj.sensitivity = sensitivitySlider.value * mySettingsObj.maxSensitivity;
        mySettingsObj.musicVolume = musicVolumeSlider.value * mySettingsObj.maxMusicVolume;

        if (musicPlayer != null)
        {
            musicPlayer.volume = mySettingsObj.musicVolume;
        }
    }
}
