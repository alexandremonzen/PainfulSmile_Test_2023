using System;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerAttack : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private bool _canShoot;

    [SerializeField] private float _timeToShootSingle = 0.5f;
    [SerializeField] private float _timeToShootMultiple = 0.9f;

    private float _timerShootSingle;
    private float _timerShootMultiple;

    public event Action SingleShotWasPerfomed;
    public event Action MultipleShotWasPerfomed;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    private void Update()
    {
        _timerShootSingle += 1 * Time.deltaTime;
        _timerShootMultiple += 1 * Time.deltaTime;
    }

    private void OnEnable()
    {
        _playerInputActions.AttackMap.AttackSingleShoot.Enable();
        _playerInputActions.AttackMap.AttackSingleShoot.performed += AttackSingleShoot;

        _playerInputActions.AttackMap.AttackMultipleShoot.Enable();
        _playerInputActions.AttackMap.AttackMultipleShoot.performed += AttackMultipleShoot;
    }

    private void OnDisable()
    {
        _playerInputActions.AttackMap.AttackSingleShoot.performed -= AttackSingleShoot;
        _playerInputActions.AttackMap.AttackSingleShoot.Disable();

        _playerInputActions.AttackMap.AttackMultipleShoot.performed -= AttackMultipleShoot;
        _playerInputActions.AttackMap.AttackMultipleShoot.Disable();
    }

    private void AttackSingleShoot(InputAction.CallbackContext obj)
    {
        if (_timerShootSingle >= _timeToShootSingle)
        {
            _timerShootSingle = 0;
            SingleShotWasPerfomed?.Invoke();
        }
    }

    private void AttackMultipleShoot(InputAction.CallbackContext obj)
    {
        if (_timerShootMultiple >= _timeToShootMultiple)
        {
            _timerShootMultiple = 0;
            MultipleShotWasPerfomed?.Invoke();
        }
    }
}
