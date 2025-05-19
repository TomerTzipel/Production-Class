using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/Player/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public float MaxSpeed { get; private set; }
    [field:SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float DashForce { get; private set; }
}
