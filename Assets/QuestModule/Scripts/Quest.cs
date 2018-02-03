using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType { SendSupplyDrone, SendBattleDrone, Tutorial, FixAntenna }

public class Quest : MonoBehaviour {

    private Data data;
    private bool isActive = false;
    [SerializeField]
    private QuestType questType;
    [SerializeField]
    private string questGiverName;
    private BaseContainer questBase;
    private List<DialogueSO> dialogue;

    public bool IsActive()
    {
        return isActive;
    }

    public void SetState(bool isActive)
    {
        this.isActive = isActive;
    }

    public QuestType GetQuestType()
    {
        return questType;
    }

    public void SetData(QuestSO dataObject)
    {
        questType = dataObject.questType;
        dialogue = dataObject.dialogue;
        questBase = dataObject.baseContainer;
        questGiverName = dataObject.baseContainer.GetBaseCaptainName();
    }

    public List<DialogueSO> GetDialogueObjects()
    {
        return dialogue;
    }

    public string GetQuestGiverName()
    {
        return questGiverName;
    }
}
