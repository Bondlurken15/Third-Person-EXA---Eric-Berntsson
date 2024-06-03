using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] DifferentMeleeAttacks meleeAttackObj;
    
    [SerializeField] float lifetime;
    
    void Start()
    {
        
    }

    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var tryEnemy = other.gameObject.GetComponent<EnemyHealth>();
        if (tryEnemy != null)
        {
            tryEnemy.TakeDamage(meleeAttackObj.damage);
            
            if (meleeAttackObj.meleeAttackEffect != null)
            {
                Instantiate(meleeAttackObj.meleeAttackEffect, transform.position, Quaternion.identity);
            }
        }
        var tryDummyEnemy = other.gameObject.GetComponent<EnemyDummyHealth>();
        if (tryDummyEnemy != null)
        {
            tryDummyEnemy.DisplayDamage(meleeAttackObj.damage);

            if (meleeAttackObj.meleeAttackEffect != null)
            {
                Instantiate(meleeAttackObj.meleeAttackEffect, transform.position, Quaternion.identity);
            }
        }
    }
}
