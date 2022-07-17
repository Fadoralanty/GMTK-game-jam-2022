using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    public Transform Weapon;
    public Transform target;

    private void Start()
    {
        target = GameManager.instance.playerTransform;
    }
    private void Update()
    {
        Vector3 aimDir = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Weapon.eulerAngles = new Vector3(0, 0, angle);
        
    }

}
