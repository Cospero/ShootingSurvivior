using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: Hp
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootDelay;


    private float shootTimer;
    

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 step = new Vector3(hor, ver, 0);

        transform.position += step * moveSpeed * Time.deltaTime;

        

        
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && shootTimer >= shootDelay)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shootDirection = mousePosition - transform.position;
            shootDirection.z = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rbody = bullet.GetComponent<Rigidbody2D>();
            rbody.velocity = shootDirection.normalized * shootSpeed;

            shootTimer = 0f;
        }

        shootTimer += Time.deltaTime;
    }
}


