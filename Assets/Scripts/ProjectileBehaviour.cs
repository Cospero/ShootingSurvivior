using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool destroyOnHit;

    [SerializeField] private float detectionRadius = 10f;
    private Rigidbody2D _rigidbody2D;
    private Collider2D closestEnemy;
    private List<GameObject> _lastHitEnemy = new List<GameObject>();


    public LayerMask enemyLayer;
    [HideInInspector]
    public float _chaneCount;
    [HideInInspector]
    public float _pirceCount;


    private void Start()
    {
        _rigidbody2D=gameObject.GetComponent<Rigidbody2D>();
        //need to raplace destroy to BackToPool
        Invoke("DestroyBullet", 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool hasHealth = collision.TryGetComponent<Hp>(out var hp);
        bool otherHealth = !collision.CompareTag(tag);
        CheckHit(hasHealth, otherHealth, hp);
    }

    private void CheckHit(bool hasHealch, bool OtherHealth, Hp hp)
    {
        if (hasHealch && OtherHealth)
        {
            Debug.Log(_chaneCount + " " + _pirceCount);

            hp.TakeDamage(damage);
            _lastHitEnemy.Add(hp.gameObject);
            if (_chaneCount < 1 && _pirceCount < 1)
            {
                Destroy(gameObject);
            }
            else if (_pirceCount >= 1)
            {
                _pirceCount--;
            }
            else
            {
                Chain();
                _chaneCount--;
            }
        }
    }

    private void Chain()
    {
        closestEnemy = null;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);

        if (hitColliders.Length > 1)
        {
            foreach(Collider2D i in hitColliders)
            {
                if(!_lastHitEnemy.Contains(i.gameObject))
                {
                    closestEnemy = i;
                    break;
                }
            }

            if(closestEnemy == null)
            {
                return;
            }
            
            Vector3 shootDirection = closestEnemy.gameObject.transform.position - transform.position;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity= shootDirection.normalized * 10;
        }
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
