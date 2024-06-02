using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobBall : ProjectileBase
{
    [SerializeField] ProjectileValues lobBallObj;

    public override void Update()
    {
        base.Update();

        Vector3 movementVector = aimDirection * (lobBallObj.projectileSpeed * Time.deltaTime);
        transform.position += movementVector;
    }
    void OnCollisionEnter(Collision collision)
    {
        var tryEnemy = collision.transform.gameObject.GetComponent<EnemyHealth>();
        if (tryEnemy != null)
        {
            tryEnemy.TakeDamage(lobBallObj.projectileDamage);
        }

        if (lobBallObj.projectileExplosion != null)
        {
            ParticleSystem spawnedExplosion = Instantiate(lobBallObj.projectileExplosion, transform.position, Quaternion.identity);
            spawnedExplosion.Play();
        }

        Destroy(this.gameObject);
    }
}
