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
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        _playerAnimation.RunningSides(hor != 0);

        if (hor > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (hor < 0)  
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        _playerAnimation.RunningUP(ver > 0);

        _playerAnimation.RunningDown(ver < 0);
    }

    private void OnDieListener()
    {
        gameObject.SetActive(false);
        GameManager.instance.GameOver();
    }
}
