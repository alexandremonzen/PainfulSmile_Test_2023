using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnAnimation : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _pitchRange = 0.4f;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void PlayAudio()
    {
        _audioManager.PlayAudio3D(_audioClip, this.transform.position, _pitchRange);
    }
}
