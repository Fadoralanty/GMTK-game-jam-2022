using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{

    [SerializeField] private Damagable _damagable;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;
    private void Awake()
    {
        if(!_damagable)
            _damagable = GetComponent<Damagable>();
        _damagable.onDie.AddListener(OnDieListener);
        _damagable.onLifeChange += OnLifeChangeHandler;
    }

    private void Start()
    {
        GameManager.instance.EnemiesOnLevel.Add(gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void OnDieListener()
    {
        gameObject.SetActive(false);
        GameManager.instance.EnemiesOnLevel.Remove(gameObject);

    }
    
    public void OnLifeChangeHandler(float num)
    {
        Flash();
    }
    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Damagable>().GetDamage(_damage);
        }
    }
}
