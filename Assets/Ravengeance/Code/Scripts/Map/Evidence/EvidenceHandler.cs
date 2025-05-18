using UnityEngine;
using UnityEngine.Events;



public class EvidenceHandler : MonoBehaviour
{
    [SerializeField] private GameObject takenVisualGameObject;
    [SerializeField] private GameObject availableVisualGameObject;
    private Evidence _evidence; 

    public event UnityAction<Evidence> OnEvidenceCollect;

    public void SetEvidence(Evidence evidence)
    {
        _evidence = evidence;
        UpdateVisual();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_evidence.status == true) return;

        if (!collision.CompareTag("Player")) return;

        CollectEvidence();
    }

    private void CollectEvidence()
    {
        _evidence.status = true;
        OnEvidenceCollect.Invoke(_evidence);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (_evidence.status)
        {
            takenVisualGameObject.SetActive(true);
            availableVisualGameObject.SetActive(false);
        }
        else
        {
            takenVisualGameObject.SetActive(false);
            availableVisualGameObject.SetActive(true);
        }
    }

    
}
