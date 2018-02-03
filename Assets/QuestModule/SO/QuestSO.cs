using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestScriptableObject", menuName = "Quest", order = 1)]
public class QuestSO : ScriptableObject
{
    public List<DialogueSO> dialogue = new List<DialogueSO>();
    public QuestType questType;
    public int questLevel;
    public BaseContainer baseContainer;
}