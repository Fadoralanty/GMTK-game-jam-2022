using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Damagable _damagable;
    [SerializeField] private PlayerAnimation _playerAnimation;
    private void Awake()
    {
        if (!_damagable)
            _damagable = GetComponent<Damagable>();
        _damagable.onDie.AddListener(OnDieListener);
        if (!_playerAnimation)
            _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _playerAnimation.Running(true);
        }
        else
        {
            _playerAnimation.Running(false);

        }
    }

    private void OnDieListener()
    {
        gameObject.SetActive(false);
    }
}
