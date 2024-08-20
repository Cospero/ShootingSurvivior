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

    private Transform enemyPos;
    private float shootTimer;
    

    private void Update()
    {
        Move(); 
    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 step = new Vector3(hor, ver, 0);

        transform.position += step * moveSpeed * Time.deltaTime;
  
    } 
}


