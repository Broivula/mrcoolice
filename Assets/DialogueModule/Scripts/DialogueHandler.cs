using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

    private int selection = 1;
    private bool dialogueStarted;
    private List<DialogueSO> dialogue;
    private int lineOfDialogue = 0;
    private Quest quest;
    public Canvas canvas;
    public Canvas selectionCanvas;
    public Button selectionButton1;
    public Button selectionButton2;
    public Text text;
    public Text characterName;
    public GameController gameController;
    public QuestMachine questMachine;
    public bool isDecision = false;
    public Dialogue_text_scroller dts;

    void Update()
    {
        if (dialogueStarted && isDecision == false)
        {
            if (Input.GetKeyDown(KeyCode.E)) { PrintOneLineOfDialogue(); }
        }

        if(isDecision)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { MakeDecision(1); }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) { MakeDecision(2); }
        }
    }

    public void SetupDialogue(Quest quest)
    {
        this.quest = quest;
        dialogue = quest.GetDialogueObjects();
        lineOfDialogue = 0;
        dialogueStarted = true;
        canvas.enabled = true;
        foreach(DialogueSO d in dialogue)
        {
            if(d.characterTalking != "You")
            {
                d.characterTalking = quest.GetQuestGiverName();
            }
        }
    }

    public void PrintOneLineOfDialogue()
    {
        Debug.Log("Hello");
        // Make the char by char print later
        if (lineOfDialogue < dialogue.Count)
        {
            characterName.text = dialogue[lineOfDialogue].characterTalking;
            text.text = dialogue[lineOfDialogue].dialogueText;
            StartCoroutine(dts.TextScroller(dialogue[lineOfDialogue].characterTalking,
                dialogue[lineOfDialogue].dialogueText, 0));
            if (dialogue[lineOfDialogue].responses.Length > 0)
            { 
                //Common.ChangeCamera(gameController.GetAllCameras());
                selectionCanvas.enabled = true;
                selectionButton1.GetComponentInChildren<Text>().text = "1. " + dialogue[lineOfDialogue].responses[0];
                selectionButton2.GetComponentInChildren<Text>().text = "2. " + dialogue[lineOfDialogue].responses[1];
                isDecision = true;
            }
            else
            {
                lineOfDialogue++;
            }
        }

        else { EndDialogue(); }
    }

    public void MakeDecision(int i)
    {
        //Common.ChangeCamera(gameController.GetAllCameras());
        isDecision = false;
        text.text = "";
        characterName.text = "";
        selectionCanvas.enabled = false;
        lineOfDialogue += i;
        PrintOneLineOfDialogue();
        EndDialogue();
        if(i == 2)
        {
            questMachine.EndCurrentQuest();
        }
    }

    public void EndDialogue()
    {
        dialogueStarted = false;
        characterName.text = "";
        text.text = "";
        if(GameController.isTutorial)
        {
            questMachine.EndCurrentQuest();
        }
        canvas.enabled = false;
    }

}
