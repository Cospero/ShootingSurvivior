using UnityEngine;

public class StatUpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;          // Ссылка на PlayerStats для изменения характеристик
    public StatUpgradeData[] upgrades;       // Массив всех доступных улучшений

    private void Start()
    {
        LoadUpgrades();                      // Загрузка данных улучшений из сохранений
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
        // Применение улучшений к PlayerStats на основе названия улучшения
        switch (upgrade.statName)
        {
            case "Health":
                //playerStats.maxHealth += 10; // Пример применения
                break;
            case "AttackDamage":
                //playerStats.attackDamage += 5;
                break;
            case "MovementSpeed":
                //playerStats.movementSpeed += 0.5f;
                break;
                // Добавьте другие апгрейды по мере необходимости
        }
        //playerStats.SaveStats(); // Сохранение изменений характеристик
    }

    private void LoadUpgrades()
    {
        // Загрузка уровней улучшений из PlayerPrefs
        foreach (StatUpgradeData upgrade in upgrades)
        {
            upgrade.currentLevel = PlayerPrefs.GetInt(upgrade.statName + "Level", 0);
        }
    }

    private void SaveUpgrades()
    {
        // Сохранение уровней улучшений в PlayerPrefs
        foreach (StatUpgradeData upgrade in upgrades)
        {
            PlayerPrefs.SetInt(upgrade.statName + "Level", upgrade.currentLevel);
        }
        PlayerPrefs.Save();
    }

    // Метод для получения индекса апгрейда по данным
    public int GetUpgradeIndex(StatUpgradeData data)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i] == data) return i;
        }
        return -1;
    }
}