using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public PlayerSettings Settings { get; private set; }
    [field: SerializeField] public Rigidbody2D RigidBody { get; private set; }
    [field: SerializeField] public PlayerUiHandler UiHandler { get; private set; }
    [SerializeField] private PlayerMovementHandler movementHandler;
    [SerializeField] private PlayerJumpHandler jumpHandler;
    [SerializeField] private PlayerRecoilHandler recoilHandler;
    [SerializeField] private PlayerGroundHandler groundHandler;
    [SerializeField] private PlayerHealthHandler healthHandler;
    public PlayerInput Input { get; private set; }

    public bool IsAirborne {  get { return groundHandler.IsPlayerAirborne; } }

    public event UnityAction OnDeath { add { healthHandler.OnDeath += value; } remove { healthHandler.OnDeath -= value; } }
    public event UnityAction<int,bool> OnHealthChange { add { healthHandler.OnHealthChange += value; } remove { healthHandler.OnHealthChange -= value; } }
    private void Awake()
    {
        Input = new PlayerInput();
    }

    private void OnEnable()
    {
        Input.Movement.Move.Enable();
        Input.Movement.Jump.Enable();
        Input.Movement.Fire.Enable();
    }
    private void OnDisable()
    {
        Input.Movement.Move.Disable();
        Input.Movement.Jump.Disable();
        Input.Movement.Fire.Disable();

    }


}
