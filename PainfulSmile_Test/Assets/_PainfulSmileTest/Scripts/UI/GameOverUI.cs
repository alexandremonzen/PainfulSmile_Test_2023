using UnityEngine;
using UnityEngine.UI;

public sealed class GameOverUI : MonoBehaviour
{
    [SerializeField] private string _menuScene;

    [Header("Buttons")]
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _quitGameButton;

    private GeneralButtonsUI _generalButtonsUI;

    private void Awake()
    {
        _generalButtonsUI = GetComponent<GeneralButtonsUI>();

        _playAgainButton.onClick.AddListener(PlayAgain);
        _mainMenuButton.onClick.AddListener(GoToMenu);
        _quitGameButton.onClick.AddListener(QuitGame);
    }

    private void PlayAgain()
    {
        _generalButtonsUI.RestartScene();
    }

    private void GoToMenu()
    {
        _generalButtonsUI.LoadScene(_menuScene);
    }

    private void QuitGame()
    {
        _generalButtonsUI.CloseApplication();
    } 
}
