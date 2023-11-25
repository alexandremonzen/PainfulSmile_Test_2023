using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public sealed class SpawnEnemiesManager : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField] private float _enemySpawnTime = 5;
    [SerializeField] private bool _usePlayerPrefs = true;
    [SerializeField] private Transform[] _spawnPoints;

    [Header("Enemy prefabs")]
    [SerializeField] private Component _seekerShip;
    [SerializeField] private Component _shooterShip;

    private bool _canSpawn;
    private int _shipRandomNumber;
    private Component _shipRandomObject;

    private float _timerEnemySpawn;

    private MatchManager _matchManager;
    private GameObjectPoolManager _gameObjectPoolManager;

    private void Awake()
    {
        _matchManager = FindFirstObjectByType<MatchManager>();
        _gameObjectPoolManager = FindFirstObjectByType<GameObjectPoolManager>();

        _canSpawn = false;

        if (_usePlayerPrefs)
        {
            _enemySpawnTime = PlayerPrefs.GetFloat("EnemySpawnTime", 5f);
        }
    }

    private void OnEnable()
    {
        _matchManager.MatchWasStarted += SetCanSpawn;
    }

    private void Update()
    {
        SpawnEnemyTimer();
    }

    private void SetCanSpawn(bool condition)
    {
        _canSpawn = condition;
    }

    private void SpawnEnemyTimer()
    {
        _timerEnemySpawn += 1 * Time.deltaTime;

        if (_timerEnemySpawn >= _enemySpawnTime)
        {
            _timerEnemySpawn = 0;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (!_canSpawn)
            return;

        _shipRandomNumber = Random.Range(0, 101);

        if (_shipRandomNumber < 50)
            _shipRandomObject = _gameObjectPoolManager.GetPooledObject(_seekerShip);
        else
            _shipRandomObject = _gameObjectPoolManager.GetPooledObject(_shooterShip);

        _shipRandomObject.transform.position = _spawnPoints[RandomSpawnPoint()].transform.position;
        _shipRandomObject.transform.rotation = _spawnPoints[RandomSpawnPoint()].transform.rotation;
    }

    private int RandomSpawnPoint()
    {
        return Random.Range(0, _spawnPoints.Length);
    }
}