using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModification
{
    public string description; // �������� ����������� (��������, "+2 �������� �����")
    public System.Action<Weapon> applyModification; // ��������, ������� ����� ��������� � ������

    public WeaponModification(string description, System.Action<Weapon> applyModification)
    {
        this.description = description;
        this.applyModification = applyModification;
    }
}