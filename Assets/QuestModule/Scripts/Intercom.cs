using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercom : MonoBehaviour {
    
    public QuestMachine questMachine;
    bool enteredArea = false;

    public bool IsPlayerAtIntercom()
    {
        return enteredArea;
    }

void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            enteredArea = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            enteredArea = false;
        }
    }
}
