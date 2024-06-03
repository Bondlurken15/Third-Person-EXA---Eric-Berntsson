using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : WeaponBase
{
    [SerializeField] HitscanValues hitscanObj;

    public ParticleSystem hitParticle;

    public override bool Fire()
    {
        if (!base.Fire())
        {
            return false;
        }

        if (this.gameObject.activeSelf == true)
        {
            Hitscan();
        }

        return true;
    }

    void Hitscan()
    {
        Debug.Log("Fired!");
        
        Ray weaponRay = new Ray(mainCam.transform.position, mainCam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(weaponRay, out hit, weaponRange, ~ignoreHitMask))
        {
            Debug.Log(hit.transform.gameObject.layer);

            if (hitParticle != null)
            {
                hitParticle.Play();
                hitParticle.transform.SetParent(null);

                hitParticle.transform.position = hit.point;
                hitParticle.transform.forward = hit.normal;
                hitParticle.transform.Translate(hit.normal.normalized * 0.1f);
            }

            var tryEnemy = hit.transform.gameObject.GetComponent<EnemyHealth>();
            if (tryEnemy != null)
            {
                tryEnemy.TakeDamage(hitscanObj.hitscanDamage);
            }

            var tryEnemyDummy = hit.transform.gameObject.GetComponent<EnemyDummyHealth>();
            if (tryEnemyDummy != null)
            {
                tryEnemyDummy.DisplayDamage(hitscanObj.hitscanDamage);
            }
        }
    }
}
