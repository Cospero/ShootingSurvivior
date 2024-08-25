using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponManager : MonoBehaviour
{
    public Weapon[] weaponSlots = new Weapon[4];

    void Update()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] != null)
            {
                weaponSlots[i].TryShoot();
            }
        }
    }

    public void EquipWeapon(Weapon weapon, int slotIndex)
    {
        if (slotIndex < weaponSlots.Length)
        {
            weaponSlots[slotIndex] = weapon;
        }
    }

    public void UnequipWeapon(int slotIndex)
    {
        if (slotIndex < weaponSlots.Length)
        {
            weaponSlots[slotIndex] = null;
        }
    }

    public void ActivateNextModificationForAllWeapons()
    {
        foreach (var weapon in weaponSlots)
        {
            if (weapon != null)
            {
                weapon.ActivateNextModification();
            }
        }
    }

    //test
    public void ActivateGlobalModification()
    {
        foreach (var weapon in weaponSlots)
        {
            if (weapon != null)
            {
                GlobalBuffs.ReduceCooldown(weapon, 0.5f);
            }
        }
        
    }

    //test

}