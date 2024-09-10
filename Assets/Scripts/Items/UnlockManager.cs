using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // Словарь для хранения разблокированных предметов по ID
    private HashSet<int> unlockedItemIDs = new HashSet<int>();

    private const string SaveKey = "UnlockedItems"; // Ключ для сохранения в PlayerPrefs

    public Item[] allItems;

    private List<Item> unlockedItems = new List<Item>();

    private void Awake()
    {
        LoadUnlockedItems(); // Загружаем разблокированные предметы при старте
    }

    // Метод для разблокировки предмета
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

    // Метод для проверки, разблокирован ли предмет
    public bool IsItemUnlocked(int itemID)
    {
        return unlockedItemIDs.Contains(itemID);
    }

    public List<Item> GetUnlockedItems()
    {

        return unlockedItems;
    }

    // Метод для сохранения разблокированных предметов
    private void SaveUnlockedItems()
    {
        // Конвертируем множество ID в строку формата JSON
        string json = JsonUtility.ToJson(new ListWrapper { ids = new List<int>(unlockedItemIDs) });
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    // Метод для загрузки разблокированных предметов
    private void LoadUnlockedItems()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            // Загружаем строку и конвертируем обратно в множество ID
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

    // Класс-обертка для сериализации множества
    [System.Serializable]
    private class ListWrapper
    {
        public List<int> ids;
    }
}