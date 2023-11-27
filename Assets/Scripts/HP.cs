using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hp : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private float maxHealth;
    
    public float Health { get; private set; }

    public bool IsDeath => Health <= 0;

    public TMP_Text hpText;

    private void Start()
    {
        hpText.text = ($"{Health}/{maxHealth}");
    }

    private void Awake()
    {
        Health = maxHealth;
        
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        print("health changed:" + damage + "health:" + Health + ", " + name);
        if (isPlayer)
        {
            hpText.text = ($"{Health}/{maxHealth}");
        }
        

        if (IsDeath)
        {
            gameObject.SetActive(false);
        }

    

    }

}
