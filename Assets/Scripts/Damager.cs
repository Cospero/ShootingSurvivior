using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasHealth = collision.TryGetComponent<Hp>(out var hp);
        bool otherHealth = !collision.CompareTag(tag);
        
        if (hasHealth && otherHealth)
        {
            hp.TakeDamage(damage);
        }
    }

}
