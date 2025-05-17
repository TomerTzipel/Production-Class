using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    [SerializeField] private int levelID;
    [SerializeField] private List<EvidenceHandler> evidenceHandlers;
    [SerializeField] private List<Evidence> collectedEvidence;

    [SerializeField] private EvidenceCounterHandler counterHandler;
    private int collectedEvidenceCounter;

    void Awake()
    {

        //THIS IS TEMP WILL BE MOVED WHEN A SAVE/LOAD SYSTEM TRULY FUNCTIONS
        //THIS MEANS ONLY LEVEL 0 WORKS
        List<List<bool>> evidencesData = new List<List<bool>>
        {
            new List<bool>()
        };

        for (int i = 0; i < evidenceHandlers.Count; i++)
        {
            evidencesData[0].Add(false);
        }
        EvidenceDataManager.Load(evidencesData);
        //Up to here

        collectedEvidence = new List<Evidence>();

        collectedEvidenceCounter = 0;
        for (int i = 0; i < evidenceHandlers.Count; i++)
        {
            bool status = EvidenceDataManager.GetEvidenceStatus(levelID, i);
            evidenceHandlers[i].SetEvidence(new Evidence { evidenceID = i,levelID = levelID,status = status });
            evidenceHandlers[i].OnEvidenceCollect += CollectEvidence;
            if (status) collectedEvidenceCounter++;
        }

        counterHandler.UpdateCounter(collectedEvidenceCounter, evidenceHandlers.Count);
    }
    
    public void CollectEvidence(Evidence evidence)
    {
        collectedEvidence.Add(evidence);
        collectedEvidenceCounter++;
        counterHandler.UpdateCounter(collectedEvidenceCounter, evidenceHandlers.Count);
    }

    public void SaveCollectedEvidence()
    {
        foreach (Evidence evidence in collectedEvidence)
        {
            EvidenceDataManager.CollectEvidence(evidence);
        }
    }
}
