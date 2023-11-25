using System;

using UnityEngine;

public sealed class MatchManager : MonoBehaviour
{
    [Tooltip("In seconds")]
    [SerializeField] private float _gameSessionTime = 60;
    [SerializeField] private bool _usePlayerPrefs = true;

    public event Action<float> SessionTimeWasUpdated;
    public event Action<bool> MatchWasStarted;
    public event Action MatchWasFinished;

    private void Awake()
    {
        if (_usePlayerPrefs)
        {
            _gameSessionTime = PlayerPrefs.GetFloat("GameSessionTime", 2);
            _gameSessionTime *= 60;
        }
    }

    private void Start()
    {
        Time.timeScale = 1;

        Invoke(nameof(DelayStart), 1);
    }

    private void DelayStart()
    {
        MatchWasStarted?.Invoke(true);
    }

    private void Update()
    {
        MatchTimer();
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
            MatchWasFinished?.Invoke();
            Time.timeScale = 0;
        }
    }
}
