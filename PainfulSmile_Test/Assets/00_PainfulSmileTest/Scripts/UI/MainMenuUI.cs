using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string _gameplayScene;
    [SerializeField] private GameObject _options;

    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;

    private GeneralButtonsUI _generalButtonsUI;

    private void Awake()
    {
        _generalButtonsUI = GetComponent<GeneralButtonsUI>();
        _playButton.onClick.AddListener(PlayGame);
        _optionsButton.onClick.AddListener(Options);
    }

    private void PlayGame()
    {
        _generalButtonsUI.LoadScene(_gameplayScene);
    }

    private void Options()
    {
        _options.SetActive(true);
    }

}
