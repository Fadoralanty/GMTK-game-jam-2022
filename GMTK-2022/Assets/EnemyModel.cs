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
    [SerializeField] private AudioSource _audioSource;
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
        if (_audioSource==null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    public void OnDieListener()
    {
        GameManager.instance.EnemiesOnLevel.Remove(gameObject);
        gameObject.SetActive(false);

    }
    
    public void OnLifeChangeHandler(float num)
    {
        Flash();
        _audioSource.Play();
    }
    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
    public IEnumerator FlashRoutine()
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
