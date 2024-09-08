using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedItem : PassiveItem
{
    private float moveSpeedBonus = 0.1f;

    private void Start()
    {
        PlayerStats.instance.PlayerMoveSpeedModifire += moveSpeedBonus;
        AddModification(new Modification("+10% � �������� ������������", w => PlayerStats.instance.PlayerMoveSpeedModifire += 0.1f));
        AddModification(new Modification("+10% � �������� ������������", w => PlayerStats.instance.PlayerMoveSpeedModifire += 0.1f));
        AddModification(new Modification("+20% � �������� ������������", w => PlayerStats.instance.PlayerMoveSpeedModifire += 0.2f));
        AddModification(new Modification("+30% � �������� ������������", w => PlayerStats.instance.PlayerMoveSpeedModifire += 0.3f));
    }
}
