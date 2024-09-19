using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemUI : MonoBehaviour
{
    public TMP_Text statNameText;                // ��������� ���� ��� �������� ���������
    public Image iconImage;                  // ����������� ������ ���������
    public TMP_Text levelText;                   // ��������� ���� ��� ����������� ������

    private StatUpgradeData upgradeData;
    private System.Action onSelected;

    public void Setup(StatUpgradeData data, System.Action onSelectedCallback)
    {
        upgradeData = data;
        onSelected = onSelectedCallback;
        UpdateUI();

        // ��������� ���������� ������� �� ������� ���������
        //GetComponent<Button>().onClick.AddListener(() => onSelected.Invoke());
    }

    public void UpdateUI()
    {
        statNameText.text = upgradeData.statName;
        levelText.text = $"Level: {upgradeData.currentLevel}/{upgradeData.maxLevel}";
        iconImage.sprite = upgradeData.icon;
    }
}