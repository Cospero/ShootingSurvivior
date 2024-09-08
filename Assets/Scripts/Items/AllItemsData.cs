using UnityEngine;

[CreateAssetMenu(fileName = "AllItemsData", menuName = "ScriptableObjects/AllItemsData", order = 1)]
public class AllItemsData : ScriptableObject
{
    public Item[] items;  // Массив всех доступных предметов

    // Получение предмета по его ID
    public Item GetItemById(int id)
    {
        foreach (var item in items)
        {
            if (item.uniqueId == id)
                return item;
        }
        return null;
    }
}