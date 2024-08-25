using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public WeaponManager weaponManager;
    public GameObject weaponSlots;
    private Weapon weaponTest;

    void Start()
    {
        Weapon weapon1 = Instantiate(Resources.Load<Weapon>("Weapons/SimpleGun"), transform.position, Quaternion.identity);
        weaponManager.EquipWeapon(weapon1, 0);
        weapon1.transform.SetParent(weaponSlots.transform);
        weaponTest= weapon1;
        // Открытие первого уровня модификации
        //weapon1.ActivateNextModification();
    }

    //test
    public void LevelUpFirstWeapon()
    {
        weaponTest.ActivateNextModification();
    }
    //test
    public void GiveNewWeapon()
    {
        Weapon weapon2 = Instantiate(Resources.Load<Weapon>("Weapons/SimpleGun1"), transform.position, Quaternion.identity);
        weaponManager.EquipWeapon(weapon2, 1);
        weapon2.transform.SetParent(weaponSlots.transform);
    }

    void OnLevelComplete()
    {
        // Открытие следующего уровня модификации для всех оружий после завершения уровня
        weaponManager.ActivateNextModificationForAllWeapons();
    }
}