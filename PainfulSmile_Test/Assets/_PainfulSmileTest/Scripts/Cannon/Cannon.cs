using System;
using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    [SerializeField] protected CannonBall _cannonBall;

    protected Transform _offsetShoot;
    protected IDamageable _damageable;

    protected CannonBallPoolManager _objectPooler;

    public event Action CannonShooted;

    protected virtual void Awake()
    {
        _offsetShoot = transform.GetChild(0);
        _damageable = GetComponentInParent<IDamageable>();

        _objectPooler = FindFirstObjectByType<CannonBallPoolManager>();
    }

    public virtual void ShootCannonBall()
    {
        CannonBall cannonBall = _objectPooler.GetPooledObject(_cannonBall);
        cannonBall.gameObject.SetActive(true);
        cannonBall.BeShooted(_offsetShoot.transform.up, _offsetShoot, _damageable);

        CannonShooted?.Invoke();
    }

}
