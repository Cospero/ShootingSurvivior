using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalBuffs
{
    public static void IncreaseDamage(Weapon weapon, float multiplier)
    {
        weapon.SetDamage(weapon.GetDamage() * multiplier);
    }

    public static void IncreaseProjectileSpeed(Weapon weapon, float multiplier)
    {
        weapon.SetProjectileSize(weapon.GetProjectileSize() * multiplier);
    }

    public static void ReduceCooldown(Weapon weapon, float multiplier)
    {
        weapon.SetCooldown(weapon.GetCooldown() * multiplier);
    }

    /*public static void ApplyAreaOfEffectBuff(Weapon weapon, float areaMultiplier)
    {
        if (weapon is AreaWeapon)
        {
            weapon.SetProjectileSize(weapon.GetProjectileSize() * areaMultiplier);
        }
    }*/
}