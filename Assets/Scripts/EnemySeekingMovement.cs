using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySeekingMovement : MonoBehaviour
{
    Transform playerTransform;

    [SerializeField] float speed;
    [SerializeField] float detectionDistance;

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
                Quaternion.LookRotation(playerTransform.transform.position - transform.position);

                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * speed);
            }
        }
    }
}
