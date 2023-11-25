using System;

using UnityEngine;

public sealed class ScoreManager : MonoBehaviour
{
    private int _totalScore;
    public int TotalScore { get => _totalScore; }

    public event Action<int> ScoreWasUpdated;

    private void Awake()
    {
        _totalScore = 0;
    }

    public void AddScore(int scoreToAdd)
    {
        _totalScore += scoreToAdd;
        ScoreWasUpdated?.Invoke(_totalScore);
    }
}
