using UnityEngine;

[CreateAssetMenu(fileName = "HealthShipSprites", menuName = "ScriptableObjects/HealthShipSprites")]
public class HealthShipSprites : ScriptableObject
{
    [Header("Sprites")]
    [SerializeField] private Sprite[] _spritesState;

    public Sprite[] SpritesState { get => _spritesState; }
}
