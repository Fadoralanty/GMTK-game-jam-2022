using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RandomChange : MonoBehaviour
{
    [SerializeField] Weapon_Shoot weapon;
    [SerializeField] Weapon_Shoot[] weapons;
    bool nextWeapon;

    void Start()
    {
        ChooseRandomWeapon();
    }

    void Update()
    {
        if(weapon.ammoAmount <= 0 && nextWeapon)
        {
            Invoke("ChooseRandomWeapon", 0.5f);
            nextWeapon = false;
        }
    }

    void ChooseRandomWeapon()
    {
        int a = Random.Range(0, weapons.Length);

        weapon = weapons[a];

        nextWeapon = true;
    }

}
