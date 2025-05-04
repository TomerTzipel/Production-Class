using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerSettings Settings { get; private set; }
    [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
    [SerializeField] private PlayerMovementHandler movementHandler;
    [SerializeField] private PlayerJumpHandler jumpHandler;
    [SerializeField] private PlayerDashHandler dashHandler;

    public PlayerInput Input { get; private set; }

    private void Awake()
    {
        Input = new PlayerInput();
    }

    private void OnEnable()
    {
        Input.Movement.Move.Enable();
        Input.Movement.Jump.Enable();
        Input.Movement.Dash.Enable();
    }
    private void OnDisable()
    {
        Input.Movement.Move.Disable();
        Input.Movement.Jump.Disable();
        Input.Movement.Dash.Disable();

    }


}
