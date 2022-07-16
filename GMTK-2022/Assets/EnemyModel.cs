using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{

    [SerializeField] private Damagable _damagable;
    [SerializeField] private float _damage = 20f;
    private void Awake()
    {
        if(!_damagable)
            _damagable = GetComponent<Damagable>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Damagable>().GetDamage(_damage);
        }
    }
}