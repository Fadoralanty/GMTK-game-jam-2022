using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=fuGQFdhSPg4&list=PLCFFG-BQwt311RcBeRnOmpgyI8KbuAn5F&index=1
public class PlayerAimWeapon : MonoBehaviour
{
     public Transform Weapon;

    private void Update()
    {
        Vector3 mousePos = GetMouseWorldPosWithZ(Input.mousePosition, Camera.main); //tal vez haya que modificar esto
        mousePos.z = 0;
        
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Weapon.eulerAngles = new Vector3(0, 0, angle);
        
    }

    private Vector3 GetMouseWorldPosWithZ(Vector3 screenPos, Camera worldCamera)
    {
        Vector3 worldPos = worldCamera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}
