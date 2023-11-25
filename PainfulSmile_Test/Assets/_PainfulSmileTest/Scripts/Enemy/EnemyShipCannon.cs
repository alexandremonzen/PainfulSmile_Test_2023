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
}
