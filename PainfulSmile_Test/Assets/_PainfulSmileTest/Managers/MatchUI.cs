using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _sessionTimeLeft;
    [SerializeField] private TMP_Text _score;
    
    private MatchManager _matchManager;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _matchManager = FindFirstObjectByType<MatchManager>();
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnEnable()
    {
        _matchManager.SessionTimeWasUpdated += UpdateSessionTimeLeft;
        _matchManager.MatchWasFinished += SetSessionTimeLeftDefault;

        _scoreManager.ScoreWasUpdated += ScoreWasUpdated;
    }

    private void OnDisable()
    {
        _matchManager.SessionTimeWasUpdated -= UpdateSessionTimeLeft;
        _matchManager.MatchWasFinished -= SetSessionTimeLeftDefault;

        _scoreManager.ScoreWasUpdated -= ScoreWasUpdated;
    }

    private void UpdateSessionTimeLeft(float timeLeft)
    {
        _sessionTimeLeft.text = $"Timer: {Mathf.Floor(timeLeft / 60).ToString("00")}:{(timeLeft % 60).ToString("00")}";
    }

    private void SetSessionTimeLeftDefault()
    {
        _sessionTimeLeft.text = "Timer: 00:00";
    }

    private void ScoreWasUpdated(int score)
    {
        _score.text = $"Score: {score}";
    }
}
