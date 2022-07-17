using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] float bulletsSpeed = 10f;
    [SerializeField] float shootDelay = 0.5f;
    [SerializeField] int ammoAmount = 1000;
    int startAmmo;

    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] Transform spawnPoint;
    private Transform target;
    private Quaternion TargetRotation;
    bool _canShoot;

    void Awake()
    {
        _canShoot = true;
    }
    
    private void Start()
    {
        target = GameManager.instance.playerTransform;
    }

    private void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        TargetRotation.eulerAngles = new Vector3(0, 0, angle);
    }

    public IEnumerator Co_ShootBullets()
    {
        _canShoot = false;
        ShootBullets();

        yield return new WaitForSeconds(shootDelay);

        _canShoot = true;
    }

    public void ShootBullets()
    {
        Rigidbody2D bulletInstance;
        bulletInstance = Instantiate(bulletPrefab, spawnPoint.position, TargetRotation);
        bulletInstance.velocity = spawnPoint.right * bulletsSpeed;
        ammoAmount--;
    }
}
