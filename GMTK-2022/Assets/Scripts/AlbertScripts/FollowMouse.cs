using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 _mousePosition;
    Camera _camera;

    void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = transform.position.z;

        transform.position = _mousePosition;
    }

}
