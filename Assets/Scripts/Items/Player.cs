using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemManager weaponManager;
    public GameObject weaponSlots;
    private Weapon weaponTest;

    void Start()
    {
        Weapon weapon1 = Instantiate(Resources.Load<Weapon>("Weapons/SimpleGun"), transform.position, Quaternion.identity);
        weaponManager.EquipItem(weapon1);
        weapon1.transform.SetParent(weaponSlots.transform);
        weaponTest = weapon1;

        PassiveItem passiveItem = Instantiate(Resources.Load<PassiveItem>("Weapons/HeartItem"), transform.position, Quaternion.identity);
        weaponManager.EquipItem(passiveItem);
        passiveItem.transform.SetParent(weaponSlots.transform);
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
        weaponManager.EquipItem(weapon2);
        weapon2.transform.SetParent(weaponSlots.transform);
    }

}
