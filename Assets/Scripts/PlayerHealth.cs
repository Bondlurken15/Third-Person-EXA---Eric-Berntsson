using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    
    [SerializeField] int health = 10;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        //healthText.text = health.ToString();

        if (health <= 0)
        {
            sceneLoader.ReloadScene();
        }
    }
}
