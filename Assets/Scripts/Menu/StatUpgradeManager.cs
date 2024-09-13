using UnityEngine;

public class StatUpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;          // ������ �� PlayerStats ��� ��������� �������������
    public StatUpgradeData[] upgrades;       // ������ ���� ��������� ���������

    private void Start()
    {
        LoadUpgrades();                      // �������� ������ ��������� �� ����������
    }

    public void UpgradeStat(int index)
    {
        if (index < 0 || index >= upgrades.Length) return;

        StatUpgradeData upgrade = upgrades[index];
        if (upgrade.currentLevel < upgrade.maxLevel)
        {
            upgrade.currentLevel++;
            ApplyUpgrade(upgrade);
            SaveUpgrades();
        }
    }

    private void ApplyUpgrade(StatUpgradeData upgrade)
    {
        // ���������� ��������� � PlayerStats �� ������ �������� ���������
        switch (upgrade.statName)
        {
            case "Health":
                //playerStats.maxHealth += 10; // ������ ����������
                break;
            case "AttackDamage":
                //playerStats.attackDamage += 5;
                break;
            case "MovementSpeed":
                //playerStats.movementSpeed += 0.5f;
                break;
                // �������� ������ �������� �� ���� �������������
        }
        //playerStats.SaveStats(); // ���������� ��������� �������������
    }

    private void LoadUpgrades()
    {
        // �������� ������� ��������� �� PlayerPrefs
        foreach (StatUpgradeData upgrade in upgrades)
        {
            upgrade.currentLevel = PlayerPrefs.GetInt(upgrade.statName + "Level", 0);
        }
    }

    private void SaveUpgrades()
    {
        // ���������� ������� ��������� � PlayerPrefs
        foreach (StatUpgradeData upgrade in upgrades)
        {
            PlayerPrefs.SetInt(upgrade.statName + "Level", upgrade.currentLevel);
        }
        PlayerPrefs.Save();
    }

    // ����� ��� ��������� ������� �������� �� ������
    public int GetUpgradeIndex(StatUpgradeData data)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i] == data) return i;
        }
        return -1;
    }
}