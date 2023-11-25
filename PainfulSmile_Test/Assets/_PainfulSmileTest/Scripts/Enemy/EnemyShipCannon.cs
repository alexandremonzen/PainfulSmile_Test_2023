using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyShipCannon : Cannon
{
    private ShooterAI _shooterAI;

    protected override void Awake()
    {
        base.Awake();
        _shooterAI = GetComponentInParent<ShooterAI>();
    }

    private void OnEnable()
    {
        _shooterAI.ShootWasPerformed += ShootCannonBall;
    }

    private void OnDisable()
    {
        _shooterAI.ShootWasPerformed -= ShootCannonBall;
    }

    public void ShootCannonBall()
    {
        CannonBall cannonBall = _objectPooler.GetPooledObject(_cannonBall);
        cannonBall.gameObject.SetActive(true);
        cannonBall.BeShooted(_offsetShoot.transform.up, _offsetShoot, _damageable);
    }
}
