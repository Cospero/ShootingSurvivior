using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController: Hp, PlayerStatsObserver
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float shootDelay;

    public TMP_Text hpText;

    private void Start()
    {
        ChangeHealthUI();
    }

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

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        ChangeHealthUI();
    }

    public void ChangeHealthUI()
    {
        hpText.text = ($"{Health}/{maxHealth}");
    }


    public void OnHealthChanged(float newHealth)
    {
        float oldMaxHealth = maxHealth;
        maxHealth = newHealth;  
        Health += newHealth-oldMaxHealth;
        
        Debug.Log("Player health updated: " + maxHealth);
        ChangeHealthUI();
    }

   

    private void OnEnable()
    {
        
        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.RegisterPlayerObserver(this);
        }
    }

    private void OnDisable()
    {
        if (PlayerStats.instance != null)
        {
            PlayerStats.instance.UnregisterPlayerObserver(this);
        }
    }

    public void OnSpeedChanged(float newSpeed)
    {
        //
    }
}


