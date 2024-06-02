using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public WeaponState weaponType = WeaponState.Total;
    public int ammunition = 100;
    //public int maxAmmunition = 100;
    //public int damage;
    public float weaponRange = 13337;
    public LayerMask ignoreHitMask;

    protected Camera mainCam;

    public virtual void Start()
    {
        mainCam = Camera.main;
    }

    public virtual bool Fire()
    {
        if (ammunition < 1)
        {
            return false;
        }

        ammunition--;
        return true;
    }
}
