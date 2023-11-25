using System;

using UnityEngine;

public sealed class ShooterAI : MonoBehaviour
{
    [SerializeField] private float _shootIntervalTime = 1;
    [SerializeField] private float _distanceToShoot = 3;

    #region Events
    public event Action ShootWasPerformed;
    #endregion

    private float _timer;
    private IMovementAI _movementAI;

    private void Awake()
    {
        _movementAI = GetComponent<IMovementAI>();

        _timer = 0;
    }

    private void Update()
    {
        _timer += 1 * Time.deltaTime;
        CheckIfCanShoot();
    }

    private void CheckIfCanShoot()
    {
        if (!(_movementAI.GetDistanceFromTarget() <= _distanceToShoot))
            return;

        ShootAtTarget();
    }

    private void ShootAtTarget()
    {
        if (_timer < _shootIntervalTime)
            return;

        _timer = 0;
        ShootWasPerformed?.Invoke();
    }
}
