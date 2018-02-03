using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogueScriptableObject", menuName = "Dialogue", order = 1)]
public class DialogueSO : ScriptableObject
{
    public string dialogueText;
    public string characterTalking;
    public string[] responses;
}