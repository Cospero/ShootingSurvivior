using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameLogic : MonoBehaviour
{
    public UnlockManager unlockManager; // Ссылка на UnlockManager
    public Item[] allItems; // Все предметы, которые могут быть использованы в игре

    private void Start()
    {
        // Пример разблокировки предмета при выполнении определенных условий
        //unlockManager.UnlockItem(allItems[0].uniqueId);
    }

    public void TryEquipItem(int itemID)
    {
        // Проверка, что предмет разблокирован перед его использованием
        if (unlockManager.IsItemUnlocked(itemID))
        {
            Debug.Log($"Item {itemID} can be equipped!");
            // Реализация логики экипировки
        }
        else
        {
            Debug.Log($"Item {itemID} is not unlocked yet.");
        }
    }
}
