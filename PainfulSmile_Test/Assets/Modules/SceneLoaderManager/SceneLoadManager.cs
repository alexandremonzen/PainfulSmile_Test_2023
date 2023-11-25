using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoadManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private Image[] _loadBars;
    [SerializeField] private TMP_Text _textPercentageLoading;

    private FadeController _fadeController;
    private AsyncOperation _asyncOperation;
    private bool _loadIsDone;
    private Canvas _loadCanvas;

    private void Awake()
    {
        _fadeController = FindFirstObjectByType<FadeController>();
        _loadCanvas = transform.GetChild(0).GetComponent<Canvas>();
        _loadCanvas.gameObject.SetActive(false);
        _loadIsDone = false;
        UpdateProgressUI(0);
    }

    private void OnEnable()
    {
        UpdateProgressUI(0);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        _fadeController.CompleteFadeMethod(0.5f);
        yield return new WaitForSecondsRealtime(0.5f);
        UpdateProgressUI(0);
        _loadCanvas.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);
        _asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        _asyncOperation.allowSceneActivation = false;

        while (!_asyncOperation.isDone && !_loadIsDone)
        {
            UpdateProgressUI(_asyncOperation.progress);
            if (_asyncOperation.progress >= 0.9f)
            {
                UpdateProgressUI(1);
                _loadIsDone = true;
            }
            yield return null;
        }

        yield return new WaitForSecondsRealtime(3f);

        _fadeController.FadeFunctionMethod(1f, FadeType.In);
        yield return new WaitForSecondsRealtime(1f);
        _asyncOperation.allowSceneActivation = true;

        Time.timeScale = 1;
        yield return null;
    }

    private void UpdateProgressUI(float progress)
    {
        foreach (Image image in _loadBars)
        {
            image.fillAmount = progress;
        }
        _textPercentageLoading.text = (int)(progress * 100f) + "%";
    }
}
