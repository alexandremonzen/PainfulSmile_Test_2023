using System;

using UnityEngine;

public sealed class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthAttributes _healthAttributes;
    [SerializeField] private Team _team = Team.None;
    private int _maxHealth;
    private int _currentHealth;

    public int MaxHealth { get => _maxHealth; }

    #region Events
    public event Action<int> HealthValueWasChanged;
    public event Action HealthWasDepleted;
    #endregion
    
    private void Awake()
    {
        SetupHealth();
    }

    private void OnEnable()
    {
        SetupHealth();
    }

    private void SetupHealth()
    {
        _maxHealth = _healthAttributes.MaxHealth;
        _currentHealth = _maxHealth;
        HealthValueWasChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damageValue, Team team)
    {
        if(_team == team)
            return;

        _currentHealth -= damageValue;
        HealthValueWasChanged?.Invoke(_currentHealth);

        if(_currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    public void Die()
    {
        HealthWasDepleted?.Invoke();
        this.gameObject.SetActive(false);
    }

    public Team GetTeamSide()
    {
        return _team;
    }
}
