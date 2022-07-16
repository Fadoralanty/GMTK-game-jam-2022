using System.Collections;
using System.Collections.Generic;
using Plataformer2d;
using UnityEngine;

public class Weapon_Shoot : MonoBehaviour
{
    [SerializeField] float bulletsSpeed = 10f;
    [SerializeField] float shootDelay = 0.5f;
    [SerializeField] private float CamShakeIntensity = 1;
    [SerializeField] int ammoAmount;
    int startAmmo;

    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] Transform spawnPoint;

    bool _canShoot;

    void Awake()
    {
        startAmmo = ammoAmount;
        _canShoot = true;
    }

    public void ResetAmmo()
    {
        ammoAmount = startAmmo;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && _canShoot == true)
        {
            if (ammoAmount > 0)
            {
                StartCoroutine(Co_ShootBullets());
            }
            else
            {
                Weapon_RandomChange newWeapon = FindObjectOfType<Weapon_RandomChange>();
                gameObject.SetActive(false);
                newWeapon.StartChoose();
            }
        }
    }

    IEnumerator Co_ShootBullets()
    {
        _canShoot = false;
        ShootBullets();

        yield return new WaitForSeconds(shootDelay);

        _canShoot = true;
    }

    void ShootBullets()
    {
        Rigidbody2D bulletInstance;
        bulletInstance = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bulletInstance.velocity = spawnPoint.right * bulletsSpeed;
        ammoAmount--;
        CameraShake.Instance.ShakeCamera(CamShakeIntensity,shootDelay);
    }

}
