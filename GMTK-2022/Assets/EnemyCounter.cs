using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesLeft;

    private void Awake()
    {
        _enemiesLeft = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _enemiesLeft.text = "ENEMIES LEFT:" + GameManager.instance.EnemiesOnLevel.Count;
    }
}
