using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootDelay;


    private Transform enemyPos;
    private float shootTimer; 

    void Update()
    {
        //Shoot();
    }

    private void Shoot()
    {
        if (shootTimer >= shootDelay)
        {
            EnemyManager.instance.FindClosiestEnemy();
            enemyPos = EnemyManager.instance._closietsEnemy;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shootDirection = enemyPos.position - transform.position;
            shootDirection.z = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rbody = bullet.GetComponent<Rigidbody2D>();
            rbody.velocity = shootDirection.normalized * shootSpeed;
            ProjectileBehaviour proj = bullet.GetComponent<ProjectileBehaviour>();
            proj._chaneCount = 0;
            proj._pirceCount = 1;

            shootTimer = 0f;
        }

        shootTimer += Time.deltaTime;
    }
}
