using UnityEngine;

public class SpawnObjectOnDeath : MonoBehaviour
{
    [SerializeField] private Component _explosionPrefab;
    private Health _health;
    private GameObjectPoolManager _gameObjectPoolManager;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _gameObjectPoolManager = FindFirstObjectByType<GameObjectPoolManager>();
    }

    private void OnEnable()
    {
        _health.HealthWasDepleted += SpawnVFX;
    }

    private void SpawnVFX()
    {
        _gameObjectPoolManager.GetPooledObject(_explosionPrefab, this.transform);
    }
}
