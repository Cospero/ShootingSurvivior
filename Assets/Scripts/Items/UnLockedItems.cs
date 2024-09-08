using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "unlockedItemsData", menuName = "Items Data", order = 1)]
public class UnLockedItems : ScriptableObject
{
    public List<Weapon> unlockedWeapons;
    public List<PassiveItem> unlockedPassiveItems;   
}
