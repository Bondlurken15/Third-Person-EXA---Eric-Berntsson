using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    Transform playerTransform;

    [SerializeField] GameObject projectileToSpawn;
    [SerializeField] float timeBetweenShots;
    [SerializeField] float detectionDistance;

    Coroutine currentCoroutine;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= detectionDistance)
            {
                Vector3 direction = playerTransform.transform.position - transform.position;

                Vector3 spawnPosition = transform.position;

                if (currentCoroutine == null)
                {
                    currentCoroutine = StartCoroutine(ShootRoutine(direction, spawnPosition));
                }
            }
        }
    }

    IEnumerator ShootRoutine(Vector3 direction, Vector3 spawnPosition)
    {
        Instantiate(projectileToSpawn, spawnPosition, Quaternion.LookRotation(direction));

        yield return new WaitForSeconds(timeBetweenShots);

        currentCoroutine = null;
    }
}
