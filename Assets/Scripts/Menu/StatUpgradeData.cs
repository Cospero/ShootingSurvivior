using UnityEngine;

[CreateAssetMenu(fileName = "StatUpgradeData", menuName = "Game/Stat Upgrade Data")]
public class StatUpgradeData : ScriptableObject
{
    [Header("Upgrade Information")]
    public string statName;          // �������� �������������� (��������, "Health")
    public string description;       // �������� ���������
    public Sprite icon;              // ������ ��� ����������� � UI

    [Header("Upgrade Levels")]
    public int currentLevel;         // ������� ������� ���������
    public int maxLevel;             // ������������ ������� ���������
    public int baseUpgradeCost;          // ��������� ��������� �� ������ ������
    public float upgradeCostMulti;
}