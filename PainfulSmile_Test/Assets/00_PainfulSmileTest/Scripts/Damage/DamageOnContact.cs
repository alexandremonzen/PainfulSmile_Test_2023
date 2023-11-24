using System;
using UnityEngine;

public sealed class DamageOnContact : MonoBehaviour, IDamage
{
    [Header("General Config")]
    [SerializeField] private int _damageValue;
    [SerializeField] private Team _team = Team.None;
    [SerializeField] private bool _autoDestroy = true;

    [Header("Collision Types")]
    [SerializeField] private bool _onCollision = true;
    [SerializeField] private bool _onTrigger = true;

    public event Action WasDestroyed;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!_onCollision)
            return;

        IDamageable damageable = col.gameObject.GetComponent<IDamageable>();
        GiveDamage(damageable);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_onTrigger)
            return;

        IDamageable damageable = col.GetComponent<IDamageable>();
        GiveDamage(damageable);
    }

    private void GiveDamage(IDamageable damageable)
    {
        if (damageable is null)
            return;

        if (damageable.GetTeamSide() == _team)
            return;

        damageable.TakeDamage(_damageValue, _team);

        if (_autoDestroy)
        {
            WasDestroyed?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    public void SetTeamSide(Team teamSide)
    {
        _team = teamSide;
    }
}