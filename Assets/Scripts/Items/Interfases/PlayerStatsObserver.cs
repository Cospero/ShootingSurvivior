using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface PlayerStatsObserver
{
    void OnHealthChanged(float newHealth);
    void OnSpeedChanged(float newSpeed);
}