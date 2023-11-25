using UnityEngine;

[CreateAssetMenu(fileName = "HealthAttributes", menuName = "ScriptableObjects/HealthAttributes")]
public class HealthAttributes : ScriptableObject
{
    [SerializeField] private int _maxHealth;

    public int MaxHealth { get => _maxHealth; }
}
