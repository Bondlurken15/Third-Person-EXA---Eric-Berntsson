using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BowlingBall : ProjectileBase
{
    public override void Update()
    {
        base.Update();

        Vector3 movementVector = aimDirection * (movementSpeed * Time.deltaTime);
        transform.position += movementVector;
    }

    //public override void OnCollisionEnter(Collision collision)
    //{
    //    base.OnCollisionEnter(collision);

    //    movementSpeed = 0;

    //    var tryPlayer = collision.transform.gameObject.GetComponent<PlayerHealth>();
    //    if (tryPlayer != null)
    //    {
    //        tryPlayer.TakeDamage(impactDamage);
    //    }

    //    var tryEnemy = collision.transform.gameObject.GetComponent<DummyEnemy>();
    //    if (tryEnemy != null)
    //    {
    //        tryEnemy.TakeDamage(impactDamage);
    //    }
    //}
}
