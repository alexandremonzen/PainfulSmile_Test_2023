using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    [SerializeField] protected CannonBall _cannonBall;
    
    protected Transform _offsetShoot;
    protected IDamageable _damageable;

    protected CannonBallPoolManager _objectPooler;

    protected virtual void Awake()
    {
        _offsetShoot = transform.GetChild(0);
        _damageable = GetComponentInParent<IDamageable>();

        _objectPooler = FindFirstObjectByType<CannonBallPoolManager>();
    }

}
