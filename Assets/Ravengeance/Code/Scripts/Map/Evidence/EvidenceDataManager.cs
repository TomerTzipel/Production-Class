using System.Collections.Generic;
using UnityEngine;


public struct Evidence
{
    public int levelID;
    public int evidenceID;
    public bool status;
}
public static class EvidenceDataManager
{
    private static Dictionary<int, Dictionary<int, bool>> _evidenceData;

    public static bool GetEvidenceStatus(int levelID, int evidenceID)
    {
        return _evidenceData[levelID][evidenceID];
    }

    public static void CollectEvidence(Evidence evidence)
    {
        _evidenceData[evidence.levelID][evidence.evidenceID] = true;
    }

    public static void Load(List<List<bool>> data)
    {
        _evidenceData = new Dictionary<int, Dictionary<int, bool>>(10);

        for (int i = 0; i < data.Count; i++)
        {
            List<bool> evidences = data[i];
            _evidenceData.Add(i,new Dictionary<int, bool>(4));

            for (int j = 0; j < evidences.Count; j++)
            {
                bool evidenceStatus = evidences[j];
                _evidenceData[i].Add(j,evidenceStatus);
            }
        }
    }
    public static List<List<bool>> Save()
    {
        List<List<bool>> data = new List<List<bool>>(10);

        for (int i = 0; i < _evidenceData.Count; i++)
        {
            Dictionary<int, bool> evidences = _evidenceData[i];
            data.Add(new List<bool>(4));

            for (int j = 0; j < evidences.Count; j++)
            {
                bool evidenceStatus = evidences[j];
                data[i].Add(evidenceStatus);
            }
        }
        return data;
    }


}
