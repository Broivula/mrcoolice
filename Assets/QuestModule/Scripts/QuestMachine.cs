using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMachine : MonoBehaviour {

    [SerializeField]
    private Quest quest;
    private DialogueHandler dh;
    private bool isNewQuestAvailable = true;

    private int questsCompleted = 0;
    private int questLevel = 1;

    public Recali_quest rq;

    private Data data;

    private float newQuestPercentage = 33.0f;

    void Start()
    {
        dh = GameObject.Find("DialogueHandler").GetComponent<DialogueHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            EndCurrentQuest();
        }
    }

    public void CreateQuest()
    {
        // Preset all different quest types into the allQuestTypes list
        // Randomizing through enums is a fucking pain
        Instantiate(quest, Vector3.zero, Quaternion.identity);
        SetCurrentQuest(quest);
        data = GameObject.Find("Data").GetComponent<Data>();
        QuestSO questData = data.GetRandomQuestData(questLevel);
        quest.SetData(questData);
        dh.SetupDialogue(quest);
        if(questData.questType == QuestType.FixAntenna)
        {
            rq.isQuestOn = true;
        }
        isNewQuestAvailable = false;
    }

    public void CreateTutorialQuest()
    {
        Instantiate(quest, Vector3.zero, Quaternion.identity);
        SetCurrentQuest(quest);
        data = GameObject.Find("Data").GetComponent<Data>();
        QuestSO questData = data.GetTutorialQuestData();
        quest.SetData(questData);
        dh.SetupDialogue(quest);
        isNewQuestAvailable = false;
    }

    public Quest GetCurrentQuest()
    {
        return quest;
    }

	public void SetCurrentQuest(Quest quest)
    {
        // We don't wanna override the already active quest
        // Probably only useful for testing as this shouldn't happen in general
        if(this.quest.IsActive()){ Debug.Log("Active quest was overriden!"); }
        this.quest = quest;
    }

    public void EndCurrentQuest()
    {
        Debug.Log("DO we even get here");
        if(QuestCompletionRequirementsMet())
        {
            quest.SetState(false);
            StartCoroutine(NewQuestRandomizer());
            CheckForIncreasedQuestLevel();
            GameController.isTutorial = false;
        }
    }

    public bool CheckIfCurrentQuestActive()
    {
        return quest.IsActive();
    }

    public bool CheckIfNewQuestAvailable()
    {
        return isNewQuestAvailable;
    }

    private IEnumerator NewQuestRandomizer()
    {
        yield return new WaitForSeconds(Common.GetRandomWaitTime());
        Debug.Log("New quest available!");
        isNewQuestAvailable = true;
        StopCoroutine(NewQuestRandomizer());
    }

    public bool QuestCompletionRequirementsMet()
    {
        switch (quest.GetQuestType())
        {
            case QuestType.FixAntenna:
                if(rq.isQuestOn == false)
                {
                    return true;
                }
                return false;
            case QuestType.SendBattleDrone:
                if (Platform.IsDroneOnPlatform())
                {
                    return true;
                }
                return false;
            case QuestType.SendSupplyDrone:
                if (Platform.IsDroneOnPlatform())
                {
                    return true;
                }
                return false;
            case QuestType.Tutorial:
                return true;
        }

        return false;
    }

    public int GetCurrentQuestLevel()
    {
        return questLevel;
    }

    public void CheckForIncreasedQuestLevel()
    {
        questsCompleted++;
        if(questsCompleted == 2)
        {
            questLevel++;
            questsCompleted = 0;
        }
    }

}
