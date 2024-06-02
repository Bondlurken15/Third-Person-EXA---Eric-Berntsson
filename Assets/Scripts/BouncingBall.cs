using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BouncingBall : ProjectileBase
{
    [SerializeField] ProjectileValues bouncingBallObj;

    [SerializeField] LayerMask bounceableLayers;
    
    public override void Update()
    {
        base.Update();

        Vector3 movementVector = aimDirection * (bouncingBallObj.projectileSpeed * Time.deltaTime);
        transform.position += movementVector;
    }

    void OnCollisionEnter(Collision collision)
    {
        var tryEnemy = collision.transform.gameObject.GetComponent<EnemyHealth>();
        if (tryEnemy != null)
        {
            tryEnemy.TakeDamage(bouncingBallObj.projectileDamage);
        }

        if (bouncingBallObj.projectileTravelEffect != null)
        {
            ParticleSystem spawnedTravelEffect = Instantiate(bouncingBallObj.projectileTravelEffect, transform.position, Quaternion.identity);
            spawnedTravelEffect.Play();
        }
        
        if ((bounceableLayers.value & (1 << collision.gameObject.layer)) == 0)
        {
            if (bouncingBallObj.projectileExplosion != null)
            {
                ParticleSystem spawnedExplosion = Instantiate(bouncingBallObj.projectileExplosion, transform.position, Quaternion.identity);
                spawnedExplosion.Play();
            }

            Destroy(this.gameObject);
            Debug.Log("Destroy ball!");
        }
    }
}
