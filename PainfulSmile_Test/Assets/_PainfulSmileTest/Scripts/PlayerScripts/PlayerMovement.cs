using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10;

        private Vector2 _movementVector;

        private PlayerInputActions _playerInputActions;
        private InputAction _movementInputAction;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _rigidbody = GetComponent<Rigidbody2D>();
            _movementVector = Vector2.zero;
        }

        private void OnEnable()
        {
            _movementInputAction = _playerInputActions.MovementMap.Movement;
            _movementInputAction.Enable();
        }

        private void OnDisable()
        {
            _movementInputAction.Disable();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void FixedUpdate()
        {
            HandleMovementPhysics();
        }

        private void HandleMovement()
        {
            _movementVector = _movementInputAction.ReadValue<Vector2>();
        }

        private void HandleMovementPhysics()
        {
            _rigidbody.AddRelativeForce(_movementVector * _movementSpeed, ForceMode2D.Force);
        }
}
