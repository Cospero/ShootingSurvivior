using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemManager weaponManager;
    public GameObject weaponSlots;
    private Weapon weaponTest;
    [SerializeField] UnlockManager unlockManager;
    [SerializeField] Item testItem;

    void Start()
    {
        weaponManager.EquipItem(testItem);

        //unlockManager.UnlockItem(testItem.uniqueId);



        /*PassiveItem passiveItem2 = Instantiate(Resources.Load<PassiveItem>("Weapons/RegenItem"), transform.position, Quaternion.identity);
        weaponManager.EquipItem(passiveItem2);


        PassiveItem passiveItem3 = Instantiate(Resources.Load<PassiveItem>("Weapons/HeartItem"), transform.position, Quaternion.identity);
        weaponManager.EquipItem(passiveItem3);*/
 
    }

    //test
    public void LevelUpFirstWeapon()
    {
        Debug.Log(unlockManager.IsItemUnlocked(testItem.uniqueId));
        //weaponTest.ActivateNextModification();
    }
    //test
    public void GiveNewWeapon()
    {
        Weapon weapon2 = Instantiate(Resources.Load<Weapon>("Weapons/SimpleGun1"), transform.position, Quaternion.identity);
        weaponManager.EquipItem(weapon2);
        weapon2.transform.SetParent(weaponSlots.transform);
    }

}
