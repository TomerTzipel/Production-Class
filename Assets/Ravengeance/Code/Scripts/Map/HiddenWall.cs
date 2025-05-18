using UnityEngine;

public class HiddenWall : MonoBehaviour
{
    [SerializeField] private GameObject wallVisual;

    private void Awake()
    {
        wallVisual.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        wallVisual.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        wallVisual.SetActive(true);
    }
}
