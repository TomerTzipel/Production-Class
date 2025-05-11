using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunHandler : PlayerScript
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform shotgunPivotTransform;
    [SerializeField] private Transform shotgunTransform;

    private void OnEnable()
    {
        Input.Movement.Fire.performed += Fire;
    }
    private void OnDisable()
    {
        Input.Movement.Fire.performed -= Fire;
    }


    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Vector2 direction = mainCamera.WorldToScreenPoint(transform.position);
        direction -= Mouse.current.position.ReadValue();
        direction.Normalize();
        shotgunPivotTransform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    }

    private void Fire(InputAction.CallbackContext context)
    {

    }
}
