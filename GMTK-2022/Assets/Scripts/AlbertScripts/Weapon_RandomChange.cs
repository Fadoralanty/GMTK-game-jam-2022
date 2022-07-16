using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RandomChange : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    GameObject activeWeapon;

    void Start()
    {
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
        weapons[a].GetComponent<Weapon_Shoot>().ResetAmmo();
        activeWeapon = weapons[a];
    }

}
