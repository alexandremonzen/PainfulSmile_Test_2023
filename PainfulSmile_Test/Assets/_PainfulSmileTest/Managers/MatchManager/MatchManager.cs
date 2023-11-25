using System;

using UnityEngine;

public sealed class MatchManager : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField] private float _gameSessionTime = 60;
    [SerializeField] private bool _usePlayerPrefs = true;

    private Health _playerHealth;

    #region Events
    public event Action<float> SessionTimeWasUpdated;
    public event Action<bool> MatchWasStarted;
    public event Action MatchWasFinished;
    #endregion
    private void Awake()
    {
        if (_usePlayerPrefs)
        {
            _gameSessionTime = PlayerPrefs.GetFloat("GameSessionTime", 2);
            _gameSessionTime *= 60;
        }

        _playerHealth = FindFirstObjectByType<PlayerMovement>().GetComponent<Health>();
    }

    private void OnEnable()
    {
        _playerHealth.HealthWasDepleted += FinishMatchDelay;
    }

    private void OnDisable()
    {
        _playerHealth.HealthWasDepleted += FinishMatchDelay;
    }


    private void Start()
    {
        Time.timeScale = 1;

        Invoke(nameof(DelayStart), 1);
    }

    private void Update()
    {
        MatchTimer();
    }

    private void DelayStart()
    {
        MatchWasStarted?.Invoke(true);
    }

    private void MatchTimer()
    {
        _gameSessionTime -= 1 * Time.deltaTime;

        if (_gameSessionTime > 0)
        {
            SessionTimeWasUpdated?.Invoke(_gameSessionTime);
        }
        else
        {
            FinishMatchDelay();
        }
    }

    private void FinishMatchDelay()
    {
        Invoke(nameof(FinishMatch), 1);
    }

    private void FinishMatch()
    {
        MatchWasFinished?.Invoke();
        Time.timeScale = 0;
    }
}
