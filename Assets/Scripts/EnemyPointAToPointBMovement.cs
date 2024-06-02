using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointAToPointBMovement : MonoBehaviour
{
    //[SerializeField] Vector3 pointA;
    //[SerializeField] Vector3 pointB;
    [SerializeField] Vector3 distanceToMoveFromStart;
    [SerializeField] float speed;

    Vector3 pointA;
    Vector3 pointB;
    bool reachedA = true;
    bool reachedB = false;

    private void Start()
    {
        pointA = transform.position;
        pointB = transform.position + distanceToMoveFromStart;
    }

    private void Update()
    {
        if (reachedA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB, Time.deltaTime * speed);

            float distanceToPointB = Vector3.Distance(transform.position, pointB);
            if (distanceToPointB <= 0.2)
            {
                reachedA = false;
                reachedB = true;
            }
        }
        if (reachedB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA, Time.deltaTime * speed);

            float distanceToPointA = Vector3.Distance(transform.position, pointA);
            if (distanceToPointA <= 0.2)
            {
                reachedA = true;
                reachedB = false;
            }
        }
    }
}
