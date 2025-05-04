using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [field: SerializeField] protected PlayerController Controller { get; private set; }
    protected PlayerSettings Settings { get { return Controller.Settings; } }
    protected Rigidbody2D RigidBody { get { return Controller.RigidBody; } }
    protected PlayerInput Input { get { return Controller.Input; } }
}
