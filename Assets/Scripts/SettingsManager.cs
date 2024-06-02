using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Scrollbar sensitivitySlider;
    [SerializeField] SettingsValues mySettingsObj;

    void Update()
    {
        mySettingsObj.sensitivity = sensitivitySlider.value * mySettingsObj.maxSensitivity;
    }
}
