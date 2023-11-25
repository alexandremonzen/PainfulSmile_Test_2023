using System.Collections;

using UnityEngine;
using TMPro;

public sealed class RandomTextLoadScreen : MonoBehaviour
{
    [SerializeField] private PhrasesLoadingScreen _phrasesLoadingScreen;
    [SerializeField] private int _timeToChange = 6;
    private TMP_Text _text;
    private Animator _animator;
    private int _phraseIndex;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _animator = GetComponent<Animator>();
        _phraseIndex = -1;
    }

    private void OnEnable()
    {
        _phraseIndex = -1;
        _phrasesLoadingScreen.RandomizePhrasesOrder();
        StartCoroutine(SortPhrases());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator SortPhrases()
    {
        while (true)
        {
            _animator.SetBool("disabled", false);
            _text.text = _phrasesLoadingScreen.Phrases[GetIndex()];
            yield return new WaitForSecondsRealtime(_timeToChange);

            _animator.SetBool("disabled", true);
            yield return new WaitForSecondsRealtime(1);
            yield return null;
        }
    }

    private int GetIndex()
    {
        if (_phraseIndex + 1 >= _phrasesLoadingScreen.Phrases.Length)
            _phraseIndex = -1;

        _phraseIndex++;

        return _phraseIndex;
    }
}
