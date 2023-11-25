using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DeactivateAfterTime : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate = 4;

    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_timeToDeactivate);
        this.gameObject.SetActive(false);
    }
}

