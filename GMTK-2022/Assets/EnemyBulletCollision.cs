using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Damagable>().GetDamage(damage);
        }
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
    }
}
