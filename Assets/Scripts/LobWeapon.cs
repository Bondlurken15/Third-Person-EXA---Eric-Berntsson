using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobWeapon : WeaponBase
{
    public ProjectileBase projectileToSpawn;
    [SerializeField] ProjectileValues lobBallObj;

    [SerializeField] float offsetDistance = 2;
    [SerializeField] float timeBetweenShots;

    Coroutine currentCoroutine;

    public override bool Fire()
    {
        if (!base.Fire())
        {
            return false;
        }

        SpawnProjectile();

        return true;
    }

    //IEnumerator SpawnProjectile()
    //{
    //    Vector3 direction = transform.forward.normalized + new Vector3(0, bouncingBallObj.bonusVerticalDirection, 0);
    //    Vector3 spawnPosition = transform.position + new Vector3(transform.forward.normalized.x, transform.forward.normalized.y, transform.forward.normalized.z * offsetDistance);

    //    ProjectileBase spawnedProjectile = Instantiate(projectileToSpawn, spawnPosition, Quaternion.LookRotation(direction));
    //    spawnedProjectile.Init(spawnPosition, transform.position + direction * 1000);

    //    yield return new WaitForSeconds(timeBetweenShots);

    //    currentCoroutine = null;
    //}

    void SpawnProjectile()
    {
        Vector3 direction = transform.forward.normalized + new Vector3(0, lobBallObj.bonusVerticalDirection, 0);
        Vector3 spawnPosition = transform.position + new Vector3(transform.forward.normalized.x, transform.forward.normalized.y, transform.forward.normalized.z * offsetDistance);

        ProjectileBase spawnedProjectile = Instantiate(projectileToSpawn, spawnPosition, Quaternion.LookRotation(direction));
        spawnedProjectile.Init(spawnPosition, transform.position + direction * 1000);
    }
}
