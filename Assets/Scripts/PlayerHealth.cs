using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Canvas deathCanvas;
    
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
            Debug.Log("Died");
            
            if (deathCanvas != null)
            {
                deathCanvas.gameObject.SetActive(true);
            }
        }
    }
}
