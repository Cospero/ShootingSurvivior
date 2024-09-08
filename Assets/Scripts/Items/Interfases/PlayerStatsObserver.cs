using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface PlayerStatsObserver
{
    void OnMaxHealthChanged(float newHealth);
    void OnSpeedChanged(float newSpeed);

    void OnRegenChanged(float newRegen);
}