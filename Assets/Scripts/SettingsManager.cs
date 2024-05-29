using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Scrollbar sensitivitySlider;
    [SerializeField] SettingsValues mySettings;

    void Update()
    {
        mySettings.sensitivity = sensitivitySlider.value * mySettings.maxSensitivity;
    }
}
