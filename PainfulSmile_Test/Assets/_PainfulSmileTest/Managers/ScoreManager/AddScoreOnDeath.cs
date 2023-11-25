using UnityEngine;

public sealed class AddScoreOnDeath : MonoBehaviour
{
    private Health _health;
    private ScoreManager _scoreManager;

    private void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthWasDepleted += AddScore;
    }
    
    private void OnDisable()
    {
        _health.HealthWasDepleted -= AddScore;
    }

    private void AddScore()
    {
        _scoreManager.AddScore(1);
    }
}
