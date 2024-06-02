using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    Transform playerTransform;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SendCommand()
    {
        playerTransform = FindObjectOfType<PlayerHealth>().transform;
        
        if (enemy != null && playerTransform != null)
        {
            Instantiate(enemy, playerTransform.position + new Vector3(5, 0, 0), enemy.transform.rotation);
            Debug.Log("Spawned enemy");
        } 
    }
}
