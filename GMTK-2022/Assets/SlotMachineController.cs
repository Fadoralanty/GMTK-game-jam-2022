using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _detectionRange = 10;
    [SerializeField] private Damagable _damagable;
    [SerializeField] private EnemyShoot _enemyShoot;
    private Rigidbody2D _rb;
    private bool _wasDamaged;
    private float currTime = 0;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _wasDamaged = false;
    }

    private void Start()
    {
        _target = GameManager.instance.playerTransform;
        _damagable = GetComponent<Damagable>();
        _damagable.onLifeChange += OnLifeChangeHandler;
    }

    void OnLifeChangeHandler(float num)
    {
        _wasDamaged = true;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _target.position);
        if (distance < _detectionRange || _wasDamaged)
        {
            Move();
            if (currTime>=0.5f)
            {
                _enemyShoot.ShootBullets();
                currTime = 0;
            }
        }

        currTime += Time.deltaTime;
    }

    void Move()
    {
        Vector2 dir = _target.position - transform.position;
        _rb.velocity = ( _movementSpeed * Time.fixedDeltaTime * 10 * dir.normalized);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.white;
        Gizmos.DrawWireSphere(transform.position,_detectionRange);
    }
}
