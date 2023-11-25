using UnityEngine;

public sealed class DeactivateAfterTimeInvoke : MonoBehaviour
{
    [SerializeField] private float _timeToDeactivate;

    private void OnEnable()
    {
        Invoke(nameof(Deactivate), _timeToDeactivate);
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
