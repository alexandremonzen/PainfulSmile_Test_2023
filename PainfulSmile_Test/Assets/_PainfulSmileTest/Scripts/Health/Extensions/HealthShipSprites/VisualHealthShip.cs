using System;

using UnityEngine;

public sealed class VisualHealthShip : MonoBehaviour
{
    [SerializeField] private HealthShipSprites _healthShipSprites;
    private Sprite[] _spritesState;
    private int _spriteIndex;

    private SpriteRenderer _actualSpriteState;
    private Health _health;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();

        _actualSpriteState = transform.GetComponent<SpriteRenderer>();

        _spritesState = new Sprite[_healthShipSprites.SpritesState.Length];
        Array.Copy(_healthShipSprites.SpritesState, _spritesState, _healthShipSprites.SpritesState.Length);
    }

    private void OnEnable()
    {
        _health.HealthValueWasChanged += UpdateSprites;
    }

    private void OnDisable()
    {
        _health.HealthValueWasChanged -= UpdateSprites;
    }

    public void UpdateSprites(int value)
    {
        _spriteIndex = 0;

        switch (value)
        {
            case int n when n >= _health.MaxHealth / 2 && n < _health.MaxHealth:
                _spriteIndex = 1;
                break;

            case int n when n > 0 && n < _health.MaxHealth / 2:
                _spriteIndex = 2;
                break;

            default:
                break;
        }

        for (int i = 0; i < _spritesState.Length; i++)
            _actualSpriteState.sprite = _spritesState[_spriteIndex];
    }
}
