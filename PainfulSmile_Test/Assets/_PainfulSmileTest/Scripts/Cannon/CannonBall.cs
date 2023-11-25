using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CannonBall : MonoBehaviour
{
    [SerializeField] float _force = 10;
    private IDamage _damageInterface;
    private Rigidbody2D _rigidbody;

    public IDamage IDamage { get => _damageInterface; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _damageInterface = GetComponent<IDamage>();
    }

    public void BeShooted(Vector2 directionCannonBall, Transform offsetSingleShoot, IDamageable damageable)
    {
        ResetRigidbodyVelocity();
        
        transform.position = offsetSingleShoot.position;
        transform.rotation = offsetSingleShoot.rotation;

        _damageInterface.SetTeamSide(damageable.GetTeamSide());

        this.gameObject.SetActive(true);
        _rigidbody.AddForce(new Vector2(directionCannonBall.x, directionCannonBall.y) * _force, ForceMode2D.Impulse);
    }

    public void ResetRigidbodyVelocity()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
