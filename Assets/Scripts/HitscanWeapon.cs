using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : WeaponBase
{
    //public ParticleSystem hitParticle;

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override bool Fire()
    {
        if (!base.Fire())
        {
            return false;
        }

        Hitscan();

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
            
            //hitParticle.Play();
            //hitParticle.transform.SetParent(null);

            //hitParticle.transform.position = hit.point;
            //hitParticle.transform.forward = hit.normal;
            //hitParticle.transform.Translate(hit.normal.normalized * 0.1f);

            //var tryEnemy = hit.transform.gameObject.GetComponent<DummyEnemy>();
            //if (tryEnemy != null)
            //{
            //    tryEnemy.TakeDamage(damage);
            //}
        }
    }
}
