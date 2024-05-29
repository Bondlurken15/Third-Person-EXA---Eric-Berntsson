using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingWeapon : WeaponBase
{
    public ProjectileBase projectileToSpawn;
    [SerializeField] BowlingBallValues bowlingBallObj;
    
    [SerializeField] float offsetDistance = 2;

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
        Vector3 direction = transform.forward.normalized + new Vector3(0, bowlingBallObj.bonusVerticalDirection, 0);

        Vector3 spawnPosition = transform.position + new Vector3(transform.forward.normalized.x, transform.forward.normalized.y, transform.forward.normalized.z * offsetDistance);

        // Spawn projectile with rotation facing the direction
        ProjectileBase spawnedProjectile = Instantiate(projectileToSpawn, spawnPosition, Quaternion.LookRotation(direction));

        spawnedProjectile.Init(spawnPosition, transform.position + direction * 1000);
    }
}
