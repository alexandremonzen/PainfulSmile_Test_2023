using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 75;

    private Vector2 _rotationVector;

    private PlayerInputActions _playerInputActions;
    private InputAction _rotationInputAction;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotationVector = Vector2.zero;
    }

    private void OnEnable()
    {
        _rotationInputAction = _playerInputActions.RotationMap.Rotation;
        _rotationInputAction.Enable();
    }

    private void OnDisable()
    {
        _rotationInputAction.Disable();
    }

    private void Update()
    {
        HandleRotation();
    }

    private void FixedUpdate()
    {
        HandleRotationPhysics();
    }

    private void HandleRotation()
    {
        _rotationVector = _rotationInputAction.ReadValue<Vector2>();
    }

    private void HandleRotationPhysics()
    {
        _rigidbody.MoveRotation(_rigidbody.rotation + -_rotationVector.x * _rotationSpeed * Time.fixedDeltaTime);
    }
}
