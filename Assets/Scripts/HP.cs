using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] protected float maxHealth;
    [SerializeField] private GameObject _expShardPrefab;

    protected float Health;

    public bool IsDeath => Health <= 0;

    

    private void Awake()
    {
        Health = maxHealth;
        
    }


    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);

        if (IsDeath && !isPlayer)
        {
            Instantiate(_expShardPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        /*if (isPlayer && IsDeath)
        {
            SceneManager.LoadScene(0);
        }*/

    

    }

}
