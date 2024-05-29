using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;

    [SerializeField] float speed = 4;
    
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * speed);
    }
}
