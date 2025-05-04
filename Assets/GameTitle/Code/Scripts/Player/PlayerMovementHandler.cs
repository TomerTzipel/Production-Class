using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementHandler : PlayerScript
{
    private float _direction = 0f;

    private void OnEnable()
    {
        Input.Movement.Move.performed += OnMoveInput;
        Input.Movement.Move.canceled += OnMoveInput;
    }
    private void OnDisable()
    {
        Input.Movement.Move.performed -= OnMoveInput;
        Input.Movement.Move.canceled -= OnMoveInput;
    }

    private void FixedUpdate()
    {
        if (_direction == 0f) return;
        Move();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        _direction = context.action.ReadValue<float>();
    }

    private void Move()
    {
        RigidBody.AddForceX(Settings.Acceleration * _direction);
        RigidBody.linearVelocityX = Mathf.Clamp(RigidBody.linearVelocityX,-Settings.MaxSpeed, Settings.MaxSpeed);
    }
}
