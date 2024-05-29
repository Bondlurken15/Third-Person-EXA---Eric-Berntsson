using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingValues", menuName = "SettingValues")]

public class SettingsValues : ScriptableObject
{
    public float sensitivity = 1;
    public float maxSensitivity = 180;
}
