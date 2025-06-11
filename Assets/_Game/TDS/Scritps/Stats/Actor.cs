using System;
using System.Collections;
using System.Collections.Generic;
using UDEV;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [Header("Common: ")]
    public ActorStats statData;
    [LayerList]
    [SerializeField] private int _invincibleLayer;
    [LayerList]
    [SerializeField] private int _normalLayer;

    public Weapon weapon;

    protected bool _isKnockback;
    protected bool _isInvincible;
    private bool _isDead;
    private float _currentHp;

    protected Rigidbody2D _rb;
    protected Animator _anim;

    [Header("Events: ")]
    public UnityEvent OnInit;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDead;

    public bool IsDead { get => _isDead; set => _isDead = value; }
    public float CurrentHp { get => _currentHp; set => _currentHp = value; }

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {
        Init();
    }

    public virtual void Init()
    {

    }

    public virtual void TakeDamage(float _damage)
    {
        if (_damage <= 0 || _isInvincible) return;

        _currentHp -= _damage;
        KnockBack();

        if (_currentHp < 0)
        {
            _currentHp = 0;
            Die();
        }

        OnTakeDamage?.Invoke();
    }

    protected virtual void Die()
    {
        _isDead = true;
        _rb.velocity = Vector3.zero;
        OnDead?.Invoke();

        Destroy(gameObject, 0.5f);
    }

    public void KnockBack()
    {
        if (_isInvincible || _isKnockback || _isDead) return;

        _isKnockback = true;

        StartCoroutine(StopKnockBack());
    }

    IEnumerator StopKnockBack()
    {
        yield return new WaitForSeconds(statData.knockbackTime);

        _isKnockback = false;
        _isInvincible = true;

        gameObject.layer = _invincibleLayer;

        StartCoroutine(StopInvincible());
    }

    private IEnumerator StopInvincible()
    {
        yield return new WaitForSeconds(statData.invicibleTime);
        _isInvincible = false;

        gameObject.layer = _normalLayer;
    }

    protected virtual void Move()
    {

    }
}
