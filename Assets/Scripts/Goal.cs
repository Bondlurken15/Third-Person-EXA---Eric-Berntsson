using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            sceneLoader.ChangeScene(2);
        }
    }
}
