using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // ������� ��� �������� ���������������� ��������� �� ID
    private HashSet<int> unlockedItemIDs = new HashSet<int>();

    private const string SaveKey = "UnlockedItems"; // ���� ��� ���������� � PlayerPrefs

    private void Awake()
    {
        LoadUnlockedItems(); // ��������� ���������������� �������� ��� ������
    }

    // ����� ��� ������������� ��������
    public void UnlockItem(int itemID)
    {
        if (!unlockedItemIDs.Contains(itemID))
        {
            unlockedItemIDs.Add(itemID);
            SaveUnlockedItems();
            Debug.Log($"Item {itemID} unlocked!");
        }
    }

    // ����� ��� ��������, ������������� �� �������
    public bool IsItemUnlocked(int itemID)
    {
        return unlockedItemIDs.Contains(itemID);
    }

    // ����� ��� ���������� ���������������� ���������
    private void SaveUnlockedItems()
    {
        // ������������ ��������� ID � ������ ������� JSON
        string json = JsonUtility.ToJson(new ListWrapper { ids = new List<int>(unlockedItemIDs) });
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    // ����� ��� �������� ���������������� ���������
    private void LoadUnlockedItems()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            // ��������� ������ � ������������ ������� � ��������� ID
            string json = PlayerPrefs.GetString(SaveKey);
            ListWrapper wrapper = JsonUtility.FromJson<ListWrapper>(json);
            unlockedItemIDs = new HashSet<int>(wrapper.ids);
        }
    }

    // �����-������� ��� ������������ ���������
    [System.Serializable]
    private class ListWrapper
    {
        public List<int> ids;
    }
}