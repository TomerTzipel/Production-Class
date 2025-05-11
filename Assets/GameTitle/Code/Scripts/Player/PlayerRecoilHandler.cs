using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecoilHandler : PlayerScript
{

    [SerializeField] private Transform shotgunTransform;
    private void OnEnable()
    {
        Input.Movement.Fire.performed += Recoil;
    }
    private void OnDisable()
    {
        Input.Movement.Fire.performed -= Recoil;
    }

    private void Recoil(InputAction.CallbackContext context)
    {
        Vector2 direction = transform.position - shotgunTransform.position;
        direction.Normalize();
        Debug.Log("D:" + direction);
        RigidBody.AddForce(Settings.DashForce * direction,ForceMode2D.Impulse);
    }
}
