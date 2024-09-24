using System;
using TMPro;
using UnityEngine;
using YG;

public class StatUpgradeManager : MonoBehaviour
{
    public PlayerStats playerStats;          // Ссылка на PlayerStats для изменения характеристик
    public StatUpgradeData[] upgrades;       // Массив всех доступных улучшений
    [SerializeField] private TMP_Text currentGoldText;
    public int currentGold { get; private set; }
    private PlayerData currentPlayerData = new PlayerData();


    private void Start()
    {
        LoadUpgrades();                      // Загрузка данных улучшений из сохранений
        currentGold = YandexGame.savesData.gold;
        if(currentGoldText != null )
        {
            currentGoldText.text = currentGold.ToString();
        }
    }

    public void AddGold(int gold)
    {
        currentGold += gold;
        if (currentGoldText != null)
        {
            currentGoldText.text = currentGold.ToString();
        }

        YandexGame.savesData.gold = currentGold;
        YandexGame.SaveProgress();
    }

    public void RemoveGold(int gold)
    {
        if(currentGold>=gold && currentGoldText != null)
        {
            currentGold-=gold;
            currentGoldText.text = currentGold.ToString();
        }
        YandexGame.savesData.gold = currentGold;
        YandexGame.SaveProgress();
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

        RemoveGold(GetUpgradeCost(upgrade));
        YandexGame.savesData.gold = currentGold;
        YandexGame.SaveProgress();
    }

    public int TryGetUpgradeCost(int index)
    {
        if (index < 0 || index >= upgrades.Length) return 0 ;

        StatUpgradeData upgrade = upgrades[index];

        double actualUpgradeCost = upgrade.baseUpgradeCost * Math.Pow(upgrade.upgradeCostMulti, upgrade.currentLevel);

        if (upgrade.currentLevel < upgrade.maxLevel)
        {
            Debug.Log(actualUpgradeCost + " upgradeCost");
            return (int)actualUpgradeCost;
        }

        return 0;
    }

    private int GetUpgradeCost(StatUpgradeData upgrade)
    {
        return (int)(upgrade.baseUpgradeCost * Math.Pow(upgrade.upgradeCostMulti, upgrade.currentLevel));
    }

    private void ApplyUpgrade(StatUpgradeData upgrade)
    {
        PlayerData upgradedData = LoadPlayerStats();
        // Применение улучшений к PlayerStats на основе названия улучшения
        switch (upgrade.statName)
        {
            case "Health":
                //YandexGame.savesData.playerMaxHealth += 20f;
                Debug.Log("UpgradeHJealth");
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
        YandexGame.SaveProgress();
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

    public void SavePlayerStats(PlayerData data)
    {
        // Преобразование объекта PlayerData в JSON строку
        string savesJson = JsonUtility.ToJson(data);

        // Запись JSON строки в файл
        //File.WriteAllText(savePath, json);
        YandexGame.savesData.saveStats = savesJson;
        YandexGame.SaveProgress();
        Debug.Log("Player stats save succeed");
    }

    public PlayerData LoadPlayerStats()
    {
        if (YandexGame.savesData.saveStats != "")
        {
            // Чтение файла с сохраненными характеристиками
            //string json = File.ReadAllText(savePath);
            string savesJson = YandexGame.savesData.saveStats;

            // Преобразование JSON строки обратно в объект PlayerData
            currentPlayerData = JsonUtility.FromJson<PlayerData>(savesJson);

            Debug.Log("Player stats loaded " );
            return currentPlayerData;
        }
        else
        {
            Debug.LogWarning("New save file created.");
            return new PlayerData(); // Вернуть null, если файл не найден
        }
    }
}