using UnityEngine;

[CreateAssetMenu(fileName = "StatUpgradeData", menuName = "Game/Stat Upgrade Data")]
public class StatUpgradeData : ScriptableObject
{
    [Header("Upgrade Information")]
    public string statName;          // Название характеристики (например, "Health")
    public string description;       // Описание улучшения
    public Sprite icon;              // Иконка для отображения в UI

    [Header("Upgrade Levels")]
    public int currentLevel;         // Текущий уровень улучшения
    public int maxLevel;             // Максимальный уровень улучшения
    public int baseUpgradeCost;          // Стоимость улучшения на каждом уровне
    public float upgradeCostMulti;
}