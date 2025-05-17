using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunHandler : PlayerScript
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform shotgunPivotTransform;
    [SerializeField] private Transform shotgunTransform;
    [SerializeField] private SpriteRenderer shotgunVisual;
    private void OnEnable()
    {
        Input.Movement.Fire.performed += Fire;
    }
    private void OnDisable()
    {
        Input.Movement.Fire.performed -= Fire;
    }


    void FixedUpdate()
    {
        Aim();
        FixFlip();
    }

    private void Aim()
    {
        Vector2 playerScreenPosition = mainCamera.WorldToScreenPoint(transform.position);
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector2 direction = playerScreenPosition - mousePosition;;

        direction.Normalize();

        if (direction.x == -1f)
        {
            shotgunPivotTransform.rotation = Quaternion.Euler(0f,0f,180f);
            return;
        }
        
        shotgunPivotTransform.rotation = Quaternion.FromToRotation(Vector2.right, direction);

        
    }

    private void FixFlip()
    {
       
        if(shotgunTransform.position.x < shotgunPivotTransform.position.x)
        {
            if (shotgunVisual.flipY != true) return;
            shotgunVisual.flipY = false;
        }
        else
        {
            if (shotgunVisual.flipY != false) return;
            shotgunVisual.flipY = true;
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {

    }
}
