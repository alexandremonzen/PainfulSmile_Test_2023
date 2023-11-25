using UnityEngine;

public sealed class PlayerCannon : Cannon
{
    [SerializeField] private PlayerCannonPlace _playerCannonPlace;
    private PlayerAttack _playerAttack;

    protected override void Awake()
    {
        base.Awake();
        _playerAttack = GetComponentInParent<PlayerAttack>();
    }

    private void OnEnable()
    {
        if(_playerCannonPlace == PlayerCannonPlace.Front)
            _playerAttack.SingleShotWasPerfomed += ShootCannonBall;

        if(_playerCannonPlace == PlayerCannonPlace.Side)
            _playerAttack.MultipleShotWasPerfomed += ShootCannonBall;
    }

    private void OnDisable()
    {
        if(_playerCannonPlace == PlayerCannonPlace.Front)
            _playerAttack.SingleShotWasPerfomed -= ShootCannonBall;

        if(_playerCannonPlace == PlayerCannonPlace.Side)
            _playerAttack.MultipleShotWasPerfomed -= ShootCannonBall;
    }
}