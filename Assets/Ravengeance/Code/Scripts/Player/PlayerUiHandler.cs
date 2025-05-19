using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUiHandler : PlayerScript
{
    //Evidence Handling
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private Image counterImage;
    [SerializeField] private Sprite collectedEvidenceSprite;

    //HP handling
    [SerializeField] private List<Image> HP;

    private void Awake()
    {
        ShowHP(Settings.HP);
    }
    private void OnEnable()
    {
        Controller.OnHealthChange += HandleTakeDamage;
    }

    private void OnDisable()
    {
        Controller.OnHealthChange -= HandleTakeDamage;
    }

    //Evidence Handling
    public void UpdateCounter(int collectedEvidenceCount, int totalEvidenceCount)
    {
        counterText.text = $"{collectedEvidenceCount:00}/{totalEvidenceCount:00}";

        if (collectedEvidenceCount == totalEvidenceCount)
        {
            counterImage.sprite = collectedEvidenceSprite;
        }
    }

    //HP Handling
    private void HandleTakeDamage(int hp, bool wasHealed)
    {
        ShowHP(hp);
    }

    private void ShowHP(int hp)
    {
        for (int i = 0; i < HP.Count; i++) 
        { 
            if(i < hp)
            {
                HP[i].gameObject.SetActive(true);
            }
            else
            {
                HP[i].gameObject.SetActive(false);
            }
        }
    }

}
