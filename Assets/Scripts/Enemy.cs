using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Hp
{
    [SerializeField] private float moveSpeed;

    private Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }


    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
