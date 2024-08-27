using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modification
{
    public string description; // �������� ����������� (��������, "+2 �������� �����")
    public System.Action<Item> applyModification; // ��������, ������� ����� ��������� � ������

    public Modification(string description, System.Action<Item> applyModification)
    {
        this.description = description;
        this.applyModification = applyModification;

    }
}
