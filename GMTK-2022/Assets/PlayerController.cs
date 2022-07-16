using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Damagable _damagable;

    private void Awake()
    {
        if (!_damagable)
            _damagable = GetComponent<Damagable>();
        _damagable.onDie.AddListener(OnDieListener);
    }

    private void OnDieListener()
    {
        gameObject.SetActive(false);
    }
}
