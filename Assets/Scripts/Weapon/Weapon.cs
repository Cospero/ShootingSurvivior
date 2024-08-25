using UnityEngine;
using System.Collections.Generic;

using UnityEngine;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public float baseDamage;
    public float baseProjectileSize;
    public float baseCooldown;
    public GameObject projectilePrefab;
    public float baseProjSpeed;
    public  Sprite weaponSprite;

    protected float currentDamage;
    protected float currentProjectileSize;
    protected float currentCooldown;
    protected float currentProjSpeed;

    protected int currentModificationLevel = 0; // ������� ������� �����������
    public List<WeaponModification> modifications = new List<WeaponModification>();

    protected float lastShotTime;

    protected Transform enemyPos;

    private bool canShoot;
    private bool canPirce;



    protected virtual void Start()
    {
        currentDamage = baseDamage;
        currentProjectileSize = baseProjectileSize;
        currentCooldown = baseCooldown;

        ApplyCurrentModification();
    }

    // ����� ��� ��������
    public void TryShoot()
    {
        if (Time.time >= lastShotTime + currentCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    // ����������� ����� ��������, ������� ������ ���� ���������� � ������ ���������� ������
    protected abstract void Shoot();

    // ����� ��� ���������� ������� �����������
    protected void ApplyCurrentModification()
    {
        if (currentModificationLevel < modifications.Count)
        {
            modifications[currentModificationLevel].applyModification(this);
            currentModificationLevel++;
        }
    }

    // ����� ��� ���������� ����� �����������
    public void AddModification(WeaponModification mod)
    {
        modifications.Add(mod);
    }

    // ����� ��� ���������� ���������� �����
    public void ApplyGlobalBuff(System.Action<Weapon> buff)
    {
        buff.Invoke(this);
    }


    public int GetWeaponCurrentLevel()
    {
        return currentModificationLevel;
    }

    // ����� ��� ��������� ���������� ������ �����������
    public void ActivateNextModification()
    {
        ApplyCurrentModification();
    }

    public void SetDamage(float value)
    {
        currentDamage = value;
    }

    public float GetDamage()
    {
        return currentDamage;
    }

    public void SetProjectileSize(float value)
    {
        currentProjectileSize = value;
    }

    public float GetProjectileSize()
    {
        return currentProjectileSize;
    }

    public void SetCooldown(float value)
    {
        currentCooldown = value;
    }

    public float GetCooldown()
    {
        return currentCooldown;
    }

    public bool ReachMaxLevel()
    {
        return currentModificationLevel >= modifications.Count;
    }

    public string GetNextModificationText()
    {
        return modifications[currentModificationLevel].description;
    }
}