using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    
    public float Health { get; private set; }

    public bool IsDeath => Health <= 0;


    private void Awake()
    {
        Health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        print("health changed:" + damage + "health:" + Health + ", " + name);

        if (IsDeath)
        {
            gameObject.SetActive(false);
        }
    }





}
