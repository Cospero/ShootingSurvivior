using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class StatUpgradeUI : MonoBehaviour
{
    public StatUpgradeManager upgradeManager;    // ������ �� �������� ���������
    public GameObject upgradeItemPrefab;         // ������ UI �������� ��������
    public Transform upgradeGrid;                // ��������� ��� UI ���������

    // ������ �� �������� �������������� ����
    public TMP_Text upgradeNameText;
    public TMP_Text upgradeDescriptionText;
    public Image upgradeIconImage;
    public Button upgradeButton;
    public GameObject upgradeWindow;
    public TMP_Text upgradeCostText;



    private List<UpgradeItemUI> upgradeItems = new List<UpgradeItemUI>();
    private StatUpgradeData selectedUpgradeData;

    private void Start()
    {
        GenerateUpgradeUI();                     // �������� UI ��������� ��� ������
        // ��������� ������������� ���� �� ������ ��������
        HideUpgradeWindow();
    }

    private void GenerateUpgradeUI()
    {
        foreach (StatUpgradeData upgradeData in upgradeManager.upgrades)
        {
            GameObject item = Instantiate(upgradeItemPrefab, upgradeGrid);
            UpgradeItemUI itemUI = item.GetComponent<UpgradeItemUI>();
            // ��������� UI �������� ��� ������ �������
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
        upgradeWindow.SetActive(true);
        // ���������� ���������� � ������������� ����
        upgradeNameText.text = upgradeData.statName;
        upgradeDescriptionText.text = upgradeData.description;
        upgradeIconImage.sprite = upgradeData.icon;

        // ���������� ������ ��������� ������ ���� ������� ���� �������������

        int upgradeCost = upgradeManager.TryGetUpgradeCost(upgradeManager.GetUpgradeIndex(upgradeData));
        bool reachMaxLevel = upgradeData.currentLevel >= upgradeData.maxLevel;
        //upgradeCostText.text = upgradeCost.ToString();
        if (!reachMaxLevel && upgradeCost <= upgradeManager.currentGold)
        {
            upgradeButton.interactable = true;
            upgradeCostText.text = upgradeCost.ToString();
        }
        else if(!reachMaxLevel)
        {
            upgradeCostText.text = upgradeCost.ToString();
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeCostText.text = "Max Level";
            upgradeButton.gameObject.SetActive(false);
        }

        // ������� ��� ���������� ��������� � ��������� ����� ��� �������� ���������
        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(OnUpgradeButtonPressed);

        // ���������� ������������� ����
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
        // ��������� ��� ������� ��������
        foreach (UpgradeItemUI itemUI in upgradeItems)
        {
            itemUI.UpdateUI();
        }

        // ��������� ������������� ����
        if (selectedUpgradeData != null)
        {
            ShowUpgradeWindow(selectedUpgradeData);
        }
    }

    private void HideUpgradeWindow()
    {
        // ������ ������������� ���� �� ������ ��������
        //upgradeButton.gameObject.SetActive(false);
        upgradeWindow.SetActive(false);
    }
}