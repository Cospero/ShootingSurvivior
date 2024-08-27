using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatSubject
{
    void RegisterPlayerObserver(PlayerStatsObserver playerObserver );
    void RegisterWeaponObserver(WeaponStatsObserver weaponObserver);
    void UnregisterPlayerObserver(PlayerStatsObserver playerObserver);
    void UnregisterWeaponObserver(WeaponStatsObserver weaponObserver);
    void NotifyDamageChanged();
    void NotifyHealthChanged();
    void NotifySpeedChanged();
}
