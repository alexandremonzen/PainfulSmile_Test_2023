using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Phrases Loading Screen", menuName = "Phrases Loading Screen")]
public sealed class PhrasesLoadingScreen : ScriptableObject
{
    [TextArea(5, 8)]
    [SerializeField] private string[] _phrases;

    public string[] Phrases { get => _phrases; }

    public void RandomizePhrasesOrder()
    {
        System.Random random = new System.Random();
        _phrases = _phrases.OrderBy(x => random.Next()).ToArray();
    }
}
