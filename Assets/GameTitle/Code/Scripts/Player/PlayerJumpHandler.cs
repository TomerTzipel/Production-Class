using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpHandler : PlayerScript
{
    private void OnEnable()
    {
        Input.Movement.Jump.performed += OnJumpInput;
    }
    private void OnDisable()
    {
        Input.Movement.Jump.performed -= OnJumpInput;
    }

    private void OnJumpInput(InputAction.CallbackContext context)
    {
        //Check if a jump is legal
        Jump();
    }

    private void Jump()
    {
        RigidBody.AddForce(Settings.JumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
