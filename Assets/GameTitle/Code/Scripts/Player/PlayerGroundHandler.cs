using UnityEngine;

public class PlayerGroundHandler : PlayerScript
{
    public bool IsPlayerAirborne { get; private set; }
    
    void Awake()
    {
        IsPlayerAirborne = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")) return;
        Debug.Log("Grounded");
        IsPlayerAirborne = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")) return;
        Debug.Log("Airborne");
        IsPlayerAirborne = true;
    }
}
