using UnityEngine;
using System.Collections.Generic;



public abstract class Weapon : Item
{
    public float baseDamage;
    public float baseProjectileSize;
    public float baseCooldown;
    public GameObject projectilePrefab;
    public float baseProjSpeed;

    protected float currentDamage;
    protected float currentProjectileSize;
    protected float currentCooldown;
    protected float currentProjSpeed;


    protected float lastShotTime;

    protected Transform enemyPos;

    private bool canShoot;
    private bool canPirce;

    protected virtual void Start()
    {
        currentDamage = baseDamage;
        currentProjectileSize = baseProjectileSize;
        currentCooldown = baseCooldown;

        //ApplyCurrentModification();
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

    

    // ����� ��� ���������� ���������� �����
    public void ApplyGlobalBuff(System.Action<Weapon> buff)
    {
        buff.Invoke(this);
    }


    

    // ����� ��� ��������� ���������� ������ �����������
    

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
}
