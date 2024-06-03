using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 10;

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        //healthText.text = health.ToString();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
