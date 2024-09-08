using UnityEngine;

[CreateAssetMenu(fileName = "AllItemsData", menuName = "ScriptableObjects/AllItemsData", order = 1)]
public class AllItemsData : ScriptableObject
{
    public Item[] items;  // ������ ���� ��������� ���������

    // ��������� �������� �� ��� ID
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