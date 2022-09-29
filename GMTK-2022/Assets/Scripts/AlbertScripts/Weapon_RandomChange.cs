using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RandomChange : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    GameObject activeWeapon;
    [SerializeField] private PlayerAimWeapon _playerAimWeapon;

    void Start()
    {
        _playerAimWeapon = GetComponentInParent<PlayerAimWeapon>();
        ChooseRandomWeapon();
    }
    
    public void StartChoose()
    {
        Invoke("ChooseRandomWeapon", 0.5f);
    }

    void ChooseRandomWeapon()
    {
        int a = Random.Range(0, weapons.Length);

        if (weapons[a] == activeWeapon)
        {
            ChooseRandomWeapon();
            return;
        }
    
        weapons[a].SetActive(true);
        _playerAimWeapon.Weapon = weapons[a].transform;
        weapons[a].GetComponent<Weapon_Shoot>().ResetAmmo();
        activeWeapon = weapons[a];
    }

}
