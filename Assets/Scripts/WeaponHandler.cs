using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
    Hitscan,
    Bouncing,
    Melee,
    Lob,
    Total
}

public class WeaponHandler : MonoBehaviour
{
    //[Header("Unarmed = Element 0 \n" + "Hitscan = Element 1 \n" + "Projectile = Element 2 \n")]

    [SerializeField] WeaponBase[] availableWeapons = new WeaponBase[(int)WeaponState.Total];
    [SerializeField] WeaponBase currentWeapon = null;
    [SerializeField] float mouseAxisBreakpoint = 1;

    float mouseAxisDelta;

    public virtual void Update()
    {
        HandleWeaponSwap();

        if (Input.GetMouseButtonDown(0) && currentWeapon != null)
        {
            currentWeapon.Fire();
        }
    }

    void HandleWeaponSwap()
    {
        mouseAxisDelta += Input.mouseScrollDelta.y;

        if (Mathf.Abs(mouseAxisDelta) > mouseAxisBreakpoint)
        {
            int swapDirection = (int)Mathf.Sign(mouseAxisDelta);
            mouseAxisDelta -= swapDirection * mouseAxisBreakpoint;

            int currentWeaponIndex = (int)currentWeapon.weaponType;
            currentWeaponIndex += swapDirection;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = (int)WeaponState.Total + currentWeaponIndex;
            }
            if (currentWeaponIndex >= (int)WeaponState.Total)
            {
                currentWeaponIndex = 0;
            }
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = availableWeapons[currentWeaponIndex];
            currentWeapon.gameObject.SetActive(true);
        }
    }

    //public void AddAmmo(int ammoToAdd, bool wantMaxAmmo)
    //{
    //    foreach (WeaponBase allWeapons in availableWeapons)
    //    {
    //        if (wantMaxAmmo)
    //        {
    //            //Set every weapons ammo to max
    //            allWeapons.Ammunition = allWeapons.maxAmmunition;
    //        }
    //        else
    //        {
    //            allWeapons.Ammunition += ammoToAdd;

    //            if (allWeapons.Ammunition > allWeapons.maxAmmunition)
    //            {
    //                allWeapons.Ammunition = allWeapons.maxAmmunition;
    //            }
    //        }
    //    }
    //}
}
