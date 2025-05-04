using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashHandler : PlayerScript
{
    [SerializeField] private Camera _camera; 

    private void OnEnable()
    {
        Input.Movement.Dash.performed += OnDashInput;
    }
    private void OnDisable()
    {
        Input.Movement.Dash.performed -= OnDashInput;
    }

    private void OnDashInput(InputAction.CallbackContext context)
    {
        //Check if we can dash
        Dash();
    }

    private void Dash()
    {
        Vector2 direction = _camera.WorldToScreenPoint(transform.position);
        direction -= Mouse.current.position.ReadValue();
        direction.Normalize();
        Debug.Log("D:" + direction);
        RigidBody.AddForce(Settings.DashForce * direction,ForceMode2D.Impulse);
    }
}
