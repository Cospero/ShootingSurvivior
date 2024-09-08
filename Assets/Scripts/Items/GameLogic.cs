using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameLogic : MonoBehaviour
{
    public UnlockManager unlockManager; // ������ �� UnlockManager
    public Item[] allItems; // ��� ��������, ������� ����� ���� ������������ � ����

    private void Start()
    {
        // ������ ������������� �������� ��� ���������� ������������ �������
        //unlockManager.UnlockItem(allItems[0].uniqueId);
    }

    public void TryEquipItem(int itemID)
    {
        // ��������, ��� ������� ������������� ����� ��� ��������������
        if (unlockManager.IsItemUnlocked(itemID))
        {
            Debug.Log($"Item {itemID} can be equipped!");
            // ���������� ������ ����������
        }
        else
        {
            Debug.Log($"Item {itemID} is not unlocked yet.");
        }
    }
}
