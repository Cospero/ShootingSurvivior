using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool ActiveItem;
    public Sprite itemSptite;
    protected int currentModificationLevel = 0; // ������� ������� �����������
    public List<Modification> modifications = new List<Modification>();

    protected virtual void ApplyCurrentModification()
    {
        if (currentModificationLevel < modifications.Count)
        {
            modifications[currentModificationLevel].applyModification(this);
            currentModificationLevel++;
        }
    }

    public virtual void AddModification(Modification mod)
    {
        modifications.Add(mod);
    }

    public virtual bool ReachMaxLevel()
    {
        return currentModificationLevel >= modifications.Count;
    }

    public string GetNextModificationText()
    {
        return modifications[currentModificationLevel].description;
    }

    public void ActivateNextModification()
    {
        ApplyCurrentModification();
    }

    public int GetWeaponCurrentLevel()
    {
        return currentModificationLevel;
    }
}

