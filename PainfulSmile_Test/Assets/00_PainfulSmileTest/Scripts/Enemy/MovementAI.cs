using UnityEngine;
using UnityEngine.AI;

public sealed class MovementAI : MonoBehaviour, IMovementAI
{
    [SerializeField] private GameObject _targetToSeek;
    [SerializeField] private float _distanceToStop = 0.1f;
    [SerializeField] private float _movementSpeed = 2;

    private bool _canMove;
    private float _distanceFromTarget;
    private Vector3 _directionVector;
    private float _angleDirection;

    private Rigidbody2D _rigidbody;
    private NavMeshAgent _navMeshAgent;
    public GameObject TargetToSeek { get => _targetToSeek; set => _targetToSeek = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _canMove = true;

        if (_targetToSeek == null)
        {
            _targetToSeek = FindObjectOfType<PlayerMovement>().gameObject;
        }
    }

    private void Update()
    {
        _directionVector = _targetToSeek.transform.position - transform.position;
        UpdateDistanceFromTarget();

        if (!_navMeshAgent.isStopped)
            CalculateRotationMoving();
        else
            CalculateRotationStopped();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void UpdateDistanceFromTarget()
    {
        _distanceFromTarget = Vector3.Distance(transform.position, _targetToSeek.transform.position);
    }

    private void CalculateRotationMoving()
    {
        if (_navMeshAgent.velocity.sqrMagnitude > 1)
            _angleDirection = Mathf.Atan2(-_navMeshAgent.velocity.x, _navMeshAgent.velocity.y) * Mathf.Rad2Deg;
    }

    private void CalculateRotationStopped()
    {
        _angleDirection = Mathf.Atan2(-_directionVector.x, _directionVector.y) * Mathf.Rad2Deg;
    }

    private void HandleMovement()
    {
        if (!_canMove)
            return;

        if (NotReachedMaxDistance())
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_targetToSeek.transform.position);
        }
        else
        {
            _navMeshAgent.isStopped = true;
        }
    }

    private void HandleRotation()
    {
        _rigidbody.rotation = _angleDirection;
    }



    public float GetDistanceFromTarget()
    {
        return _distanceFromTarget;
    }

    public bool NotReachedMaxDistance()
    {
        return _distanceFromTarget >= _distanceToStop;
    }
}
