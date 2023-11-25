using UnityEngine;

public sealed class PlayShootCannon : MonoBehaviour
{
    [SerializeField] private AudioClip _cannonShootClip;
    [SerializeField] private float _pitchRange = 0.4f;
    private Cannon _cannon;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindFirstObjectByType<AudioManager>();
        _cannon = GetComponent<Cannon>();
    }

    private void OnEnable()
    {
        _cannon.CannonShooted += PlayAudio;
    }

    private void OnDisable()
    {
        _cannon.CannonShooted -= PlayAudio;
    }

    private void PlayAudio()
    {
        _audioManager.PlayAudio3D(_cannonShootClip, this.transform.position, _pitchRange);
    }

}
