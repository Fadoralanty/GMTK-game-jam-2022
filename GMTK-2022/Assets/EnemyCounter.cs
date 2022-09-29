using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesLeft;
    private float enemyNum;

    private void Awake()
    {
        _enemiesLeft = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        enemyNum = GameManager.instance.EnemiesOnLevel.Count;
    }

    private void Update()
    {
        enemyNum = GameManager.instance.EnemiesOnLevel.Count;
        _enemiesLeft.text = "ENEMIES LEFT: " + enemyNum;
    }
}
