using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collisions : MonoBehaviour
{
    [SerializeField] private float damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Damagable>().GetDamage(damage);
        }
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        
    }

}
