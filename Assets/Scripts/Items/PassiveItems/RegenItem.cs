using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenItem : PassiveItem
{
    private float healthRegenBonus = 0.2f;

    private void Start()
    {
        PlayerStats.instance.PlayerHealthRegen += healthRegenBonus;
        AddModification(new Modification("+0.2 к регенерации хп", w => PlayerStats.instance.PlayerHealthRegen += 0.2f));
        AddModification(new Modification("+0.2 к регенерации хп", w => PlayerStats.instance.PlayerHealthRegen += 0.2f));
        AddModification(new Modification("+0.3 к регенерации хп", w => PlayerStats.instance.PlayerHealthRegen += 0.3f));
        AddModification(new Modification("+0.3 к регенерации хп", w => PlayerStats.instance.PlayerHealthRegen += 0.3f));
        AddModification(new Modification("+0.4 к регенерации хп", w => PlayerStats.instance.PlayerHealthRegen += 0.4f));
    }
}
