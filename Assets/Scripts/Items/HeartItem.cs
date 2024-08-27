using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : PassiveItem
{
    private int healtchBonus=10;

    private void Start()
    {
        PlayerStats.instance.PlayerMaxHealth += healtchBonus;
        AddModification(new Modification("+10 κ μΰκρ υο", w => PlayerStats.instance.PlayerMaxHealth += 10));
        AddModification(new Modification("+10 κ μΰκρ υο", w => PlayerStats.instance.PlayerMaxHealth += 15));
        AddModification(new Modification("+10 κ μΰκρ υο", w => PlayerStats.instance.PlayerMaxHealth += 20));
    }
}
