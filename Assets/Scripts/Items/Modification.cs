using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modification
{
    public string description; // Описание модификации (например, "+2 базового урона")
    public System.Action<Item> applyModification; // Действие, которое будет применено к оружию

    public Modification(string description, System.Action<Item> applyModification)
    {
        this.description = description;
        this.applyModification = applyModification;

    }
}
