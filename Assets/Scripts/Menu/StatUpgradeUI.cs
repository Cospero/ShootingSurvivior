using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class StatUpgradeUI : MonoBehaviour
{
    public StatUpgradeManager upgradeManager;    // Ссылка на менеджер улучшений
    public GameObject upgradeItemPrefab;         // Префаб UI элемента апгрейда
    public Transform upgradeGrid;                // Контейнер для UI элементов

    // Ссылки на элементы универсального окна
    public TMP_Text upgradeNameText;
    public TMP_Text upgradeDescriptionText;
    public Image upgradeIconImage;
    public Button upgradeButton;
    public GameObject UpgradeWindow;



    private List<UpgradeItemUI> upgradeItems = new List<UpgradeItemUI>();
    private StatUpgradeData selectedUpgradeData;

    private void Start()
    {
        GenerateUpgradeUI();                     // Создание UI элементов при старте
        // Отключаем универсальное окно до выбора апгрейда
        HideUpgradeWindow();
    }

    private void GenerateUpgradeUI()
    {
        foreach (StatUpgradeData upgradeData in upgradeManager.upgrades)
        {
            GameObject item = Instantiate(upgradeItemPrefab, upgradeGrid);
            UpgradeItemUI itemUI = item.GetComponent<UpgradeItemUI>();
            // Настройка UI элемента без кнопки покупки
            itemUI.Setup(upgradeData, () => OnUpgradeItemSelected(upgradeData));
            upgradeItems.Add(itemUI);
        }
    }

    private void OnUpgradeItemSelected(StatUpgradeData upgradeData)
    {
        selectedUpgradeData = upgradeData;
        ShowUpgradeWindow(upgradeData);
    }

    private void ShowUpgradeWindow(StatUpgradeData upgradeData)
    {
        // Обновление информации в универсальном окне
        upgradeNameText.text = upgradeData.statName;
        upgradeDescriptionText.text = upgradeData.description;
        upgradeIconImage.sprite = upgradeData.icon;

        // Активируем кнопку улучшения только если уровень ниже максимального
        upgradeButton.interactable = upgradeData.currentLevel < upgradeData.maxLevel;

        // Очищаем все предыдущие слушатели и добавляем новый для текущего улучшения
        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(OnUpgradeButtonPressed);

        // Показываем универсальное окно
        upgradeButton.gameObject.SetActive(true);
    }

    private void OnUpgradeButtonPressed()
    {
        int index = upgradeManager.GetUpgradeIndex(selectedUpgradeData);
        if (index != -1)
        {
            upgradeManager.UpgradeStat(index);
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // Обновляем все базовые элементы
        foreach (UpgradeItemUI itemUI in upgradeItems)
        {
            itemUI.UpdateUI();
        }

        // Обновляем универсальное окно
        if (selectedUpgradeData != null)
        {
            ShowUpgradeWindow(selectedUpgradeData);
        }
    }

    private void HideUpgradeWindow()
    {
        // Прячем универсальное окно до выбора апгрейда
        //upgradeButton.gameObject.SetActive(false);
        UpgradeWindow.SetActive(false);
    }
}