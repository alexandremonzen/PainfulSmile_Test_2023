using UnityEngine;

public sealed class PlayerCannon : MonoBehaviour
{
    [SerializeField] private CannonBall _cannonBall;
    [SerializeField] private PlayerCannonPlace _playerCannonPlace;
    private Transform _offsetShoot;
    private IDamageable _damageable;

    private PlayerAttack _playerAttack;
    private CannonBallPoolManager _objectPooler;

    private void Awake()
    {
        _offsetShoot = transform.GetChild(0);
        _damageable = GetComponentInParent<IDamageable>();
        _playerAttack = GetComponentInParent<PlayerAttack>();

        _objectPooler = FindFirstObjectByType<CannonBallPoolManager>();
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

    public void ShootCannonBall()
    {
        CannonBall cannonBall = _objectPooler.GetPooledObject(_cannonBall);
        cannonBall.gameObject.SetActive(true);
        cannonBall.BeShooted(_offsetShoot.transform.up, _offsetShoot, _damageable);
    }
}