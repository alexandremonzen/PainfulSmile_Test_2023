using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class SliderPrefKey : MonoBehaviour
{
    [SerializeField] private string _playerPrefKey;
    [SerializeField] private float _defaultPrefKeyValue;
    [SerializeField] private TMP_Text textSliderValue;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat(_playerPrefKey, _defaultPrefKeyValue);
        
        _slider.onValueChanged.AddListener(SetPlayerPrefValue);
        _slider.onValueChanged.AddListener(ShowTextSliderValue);

        ShowTextSliderValue(_slider.value);
    }

    public void ShowTextSliderValue(float value)
    {
        textSliderValue.text = value.ToString();
    }

    public void SetPlayerPrefValue(float value)
    {
        PlayerPrefs.SetFloat(_playerPrefKey, value);
    }
}