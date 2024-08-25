using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModification
{
    public string description; // Описание модификации (например, "+2 базового урона")
    public System.Action<Weapon> applyModification; // Действие, которое будет применено к оружию

    public WeaponModification(string description, System.Action<Weapon> applyModification)
    {
        this.description = description;
        this.applyModification = applyModification;
    }
}