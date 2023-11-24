using UnityEngine;

public sealed class SpawnObjectDamageOnContact : MonoBehaviour
{
    [SerializeField] private Component _explosionPrefab;
    private DamageOnContact _damageOnContact;
    private GameObjectPoolManager _gameObjectPoolManager;

    private void Awake()
    {
        _damageOnContact = GetComponent<DamageOnContact>();
        _gameObjectPoolManager = FindFirstObjectByType<GameObjectPoolManager>();
    }

    private void OnEnable()
    {
        _damageOnContact.WasDestroyed += SpawnVFX;
    }

    private void OnDisable()
    {
        _damageOnContact.WasDestroyed -= SpawnVFX;
    }

    private void SpawnVFX()
    {
        _gameObjectPoolManager.GetPooledObject(_explosionPrefab, this.transform);
    }
}
