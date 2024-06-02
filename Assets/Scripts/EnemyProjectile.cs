using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] ProjectileValues enemyProjectileObj;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 movementVector = transform.forward * (enemyProjectileObj.projectileSpeed * Time.deltaTime);
        transform.position += movementVector;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tryPlayer = collision.gameObject.GetComponent<PlayerHealth>();
        if (tryPlayer != null)
        {
            tryPlayer.TakeDamage(enemyProjectileObj.projectileDamage);
        }

        Destroy(this.gameObject);
    }
}
