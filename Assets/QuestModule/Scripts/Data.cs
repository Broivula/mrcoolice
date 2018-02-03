using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    [SerializeField]
    private List<QuestSO> scriptableObjects = new List<QuestSO>();

    public QuestSO GetRandomQuestData(int qLevel)
    {
        List<QuestSO> q = new List<QuestSO>();
        foreach(QuestSO qso in scriptableObjects)
        {
            if(qso.questLevel == qLevel)
            {
                q.Add(qso);
            }
        }
        return q[Random.Range(0, q.Count)];
    }

    public QuestSO GetTutorialQuestData()
    {
        foreach (QuestSO qso in scriptableObjects)
        {
            if (qso.questType == QuestType.Tutorial)
            {
                return qso;
            }
        }

        return null;
    }
}
