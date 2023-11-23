using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererControl : MonoBehaviour
{
    private TrailRenderer _trailRenderer;   //tirar daqui, colocar por evento

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        _trailRenderer.emitting = true;
    }

    private void OnDisable()
    {
        _trailRenderer.emitting = false;
        _trailRenderer.Clear();
    }
}
