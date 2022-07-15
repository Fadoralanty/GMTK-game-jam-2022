using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LookMouse : MonoBehaviour
{
    Rigidbody2D _rb;
    Camera _camera;

    Vector2 _mousePosition;
    float _lookAngle;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition); 
    }

    void FixedUpdate()
    {
        GetLookMouseAngle();
        LookMouse();
    }

    void GetLookMouseAngle()
    {
        Vector2 lookDir = _mousePosition - _rb.position;
        _lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    void LookMouse()
    {
        _rb.rotation = _lookAngle;
    }

}
 