using UnityEngine;

public sealed class HealthBar : MonoBehaviour
{
    [Header("Map values to fill bar")]
    [SerializeField] private float _minValueRange = 0;
    [SerializeField] private float _maxValueRange = 100;
    private float _valueMapped;

    private SpriteRenderer _spriteRenderer;
    private Health _health;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponentInParent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthValueWasChanged += UpdateFillValue;
    }

    private void OnDisable()
    {
        _health.HealthValueWasChanged -= UpdateFillValue;
    }

    private void UpdateFillValue(int value)
    {
        _valueMapped = Mathf.Lerp (_minValueRange, _maxValueRange, Mathf.InverseLerp (0, _health.MaxHealth, value));

        _spriteRenderer.material.SetFloat("_Arc", _valueMapped * 3.6f);
    }
}
