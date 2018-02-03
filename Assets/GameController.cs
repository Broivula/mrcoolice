using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Intercom intercom;
    public DialogueHandler dh;
    public QuestMachine questMachine;
    public Camera[] allCameras;
    public static bool isTutorial = true;

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && intercom.IsPlayerAtIntercom())
        {
            if(questMachine.CheckIfNewQuestAvailable() && !isTutorial)
            {
                questMachine.CreateQuest();
            }

            else if(questMachine.CheckIfNewQuestAvailable() && isTutorial)
            {
                Debug.Log("Tutorial quest made");
                questMachine.CreateTutorialQuest();
            }
        }
    }

    public Camera[] GetAllCameras()
    {
        return allCameras;
    }
}
