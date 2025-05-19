using UnityEngine;
using UnityEngine.Events;

public class EnemyEdgeDetectorHandler : MonoBehaviour
{
    public event UnityAction OnEdgeDetected;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")) return;
        OnEdgeDetected.Invoke();
    }
}
