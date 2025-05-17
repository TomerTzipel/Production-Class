using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceCounterHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private Image counterImage;
    [SerializeField] private Sprite collectedEvidenceSprite;
    public void UpdateCounter(int collectedEvidenceCount,int totalEvidenceCount)
    {
        counterText.text = $"{collectedEvidenceCount:00}/{totalEvidenceCount:00}";

        if(collectedEvidenceCount == totalEvidenceCount)
        {
            counterImage.sprite = collectedEvidenceSprite;
        }
    }
}
