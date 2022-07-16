using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameManager.instance.playerTransform;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = _target.position - transform.position;
        _rb.velocity = ( _movementSpeed * Time.fixedDeltaTime * 10 * dir.normalized);
    }
}
