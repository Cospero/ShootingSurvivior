using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SimpleGun : Weapon
{

    protected override void Start()
    {
        base.Start();

        // ��������� ���������������� ����������� �� �������
        AddModification(new Modification("+2 �������� �����", w => this.currentDamage += 10f));
        AddModification(new Modification("+1 � �������� �������", w => this.currentProjectileSize += 1f));
        AddModification(new Modification("���������� ����������� �� 10%", w => this.currentCooldown *= 0.9f));
        AddModification(new Modification("+3 �������� �����", w => this.currentDamage += 3f));
        AddModification(new Modification("���������� �������� ������� �� 20%", w => this.currentProjSpeed *= 3f));
        AddModification(new Modification("���������� ����������� �� 15%", w => this.currentCooldown *= 0.85f));
    }

    protected override void Shoot()
    {
        
        EnemyManager.instance.FindClosiestEnemy();
        enemyPos = EnemyManager.instance._closietsEnemy;
        if (enemyPos == null)
        {
            return;
        }
        Vector3 shootDirection = enemyPos.position - transform.position;
        shootDirection.z = 0;

        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection.normalized * baseProjSpeed;
        projectile.GetComponent<Projectile>().damage = currentDamage;
    }
}