using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingWeapon : WeaponBase
{
    public ProjectileBase projectileToSpawn;

    public override bool Fire()
    {
        if (!base.Fire())
        {
            return false;
        }

        SpawnProjectile();

        return true;
    }

    void SpawnProjectile()
    {
        Debug.Log("Spawned bowlingball");
        
        // Calculate direction to fire based on camera's forward direction
        Vector3 direction = mainCam.transform.forward.normalized;

        float offsetDistance = 10.0f; // Adjust this value as needed
        Vector3 spawnPosition = transform.position + direction * offsetDistance;

        // Spawn projectile with rotation facing the direction
        ProjectileBase spawnedProjectile = Instantiate(projectileToSpawn, transform.position, Quaternion.LookRotation(direction));

        spawnedProjectile.Init(spawnPosition, transform.position + direction * 1000);
    }
}
