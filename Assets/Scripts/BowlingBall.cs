using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BowlingBall : ProjectileBase
{
    [SerializeField] BowlingBallValues bowlingBallObj;

    [SerializeField] LayerMask bounceableLayers;
    
    public override void Update()
    {
        base.Update();

        Vector3 movementVector = aimDirection * (bowlingBallObj.bowlingBallSpeed * Time.deltaTime);
        transform.position += movementVector;
    }

    void OnCollisionEnter(Collision collision)
    {
        //var tryPlayer = collision.transform.gameObject.GetComponent<PlayerHealth>();
        //if (tryPlayer != null)
        //{
        //    tryPlayer.TakeDamage(impactDamage);
        //}

        var tryEnemy = collision.transform.gameObject.GetComponent<EnemyHealth>();
        if (tryEnemy != null)
        {
            tryEnemy.TakeDamage(bowlingBallObj.bowlingBallDamage);
        }

        if ((bounceableLayers.value & (1 << collision.gameObject.layer)) == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroy ball!");
        }
    }
}
