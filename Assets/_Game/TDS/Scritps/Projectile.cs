using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Base settings: ")]
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private float _currentSpeed;
    [SerializeField] private GameObject _bodyHitPrefab;

    private Vector2 _lastPosition;
    private RaycastHit2D _raycastHit;

    public float Damage { get => _damage; set => _damage = value; }

    private void Start()
    {
        _currentSpeed = _speed;
        RefreshLastPos();
    }

    void Update()
    {
        transform.Translate(transform.right * _currentSpeed * Time.deltaTime, Space.World);

        DealDamage();
        RefreshLastPos();
    }

    private void RefreshLastPos()
    {
        _lastPosition = (Vector2)transform.position;
    }
    private void DealDamage()
    {
        Vector2 rayDirection = (Vector2)transform.parent.position - _lastPosition;
        _raycastHit = Physics2D.Raycast(_lastPosition, rayDirection, rayDirection.magnitude);

        var collider = _raycastHit.collider;

        if (!_raycastHit || collider == null) return;

        if (collider.CompareTag(TagConsts.ENEMY_TAG))
        {
            DealDamageToEnemy(collider);
        }
    }

    private void DealDamageToEnemy(Collider2D _collider)
    {
        Actor actorComp = _collider.GetComponent<Actor>();

        actorComp?.TakeDamage(_damage);

        if (_bodyHitPrefab)
        {
            Instantiate(_bodyHitPrefab, (Vector3)_raycastHit.point, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDisable()
    {
        _raycastHit = new RaycastHit2D();
    }
}
