using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButtonsUI : MonoBehaviour
{
    private SceneLoadManager _sceneLoadManager;

    private void Awake()
    {
        _sceneLoadManager = FindFirstObjectByType<SceneLoadManager>();
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        _sceneLoadManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        _sceneLoadManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
