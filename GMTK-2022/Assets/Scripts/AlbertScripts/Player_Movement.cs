using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Rigidbody2D _rb;
    Vector2 _direction;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementDirection();
    }

    void MovementDirection()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        _direction = new Vector2(xMov, yMov).normalized;
    }

    void FixedUpdate()
    {
        MoveTheCharacter();
    }

    void MoveTheCharacter()
    {
        _rb.velocity = (_direction * movementSpeed * Time.fixedDeltaTime * 10);
    }

}
