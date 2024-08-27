using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface WeaponStatsObserver
{
    void OnDamageChanged(float newDamage);
}
