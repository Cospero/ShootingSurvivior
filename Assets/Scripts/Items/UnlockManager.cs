using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // ������� ��� �������� ���������������� ��������� �� ID
    private HashSet<int> unlockedItemIDs = new HashSet<int>();

    private const string SaveKey = "UnlockedItems"; // ���� ��� ���������� � PlayerPrefs

    public Item[] allItems;

    private List<Item> unlockedItems = new List<Item>();

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

    public Item GetItemByID(int id)
    {
        foreach (Item item in allItems)
        {

            if (item.uniqueId == id)
            {
                return item;
            }
        }
        //Debug.Log($"Item with ID {id} not found.");
        return null;
    }

    // ����� ��� ��������, ������������� �� �������
    public bool IsItemUnlocked(int itemID)
    {
        return unlockedItemIDs.Contains(itemID);
    }

    public List<Item> GetUnlockedItems()
    {

        return unlockedItems;
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
            FillUnlockedItems();
        }
        
    }


    private void FillUnlockedItems()
    {
        if(unlockedItems != null)
        {
            unlockedItems.Clear();
        }
        foreach(int id in unlockedItemIDs)
        {
            Debug.Log("id " + id);
            Item? item = GetItemByID(id);
            if(item != null)
            {
                unlockedItems.Add(item);
            }
        }
    }

    // �����-������� ��� ������������ ���������
    [System.Serializable]
    private class ListWrapper
    {
        public List<int> ids;
    }
}