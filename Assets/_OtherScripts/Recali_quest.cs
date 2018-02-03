using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recali_quest : MonoBehaviour {

    private Material recaliLight;
    private GameObject recaliColor;
    public Material[] emission_color;
    public AudioClip[] audioClips;
    public bool isQuestOn = false;
    int current_value = 0;
    int correct_value = 0;

    private Text display_text;

    private void Start()
    {
        display_text = GameObject.Find("Display_text").GetComponent<Text>();
     //   recaliLight = GameObject.Find("Recali_light").GetComponent<MeshRenderer>().material;
        recaliColor = GameObject.Find("Rec_light");
        display_text.text = "";
        RecQuest();
    }

    private void Update()
    {
     
    }

    public void RecQuest ()
    {
        isQuestOn = true;
        //recaliColor.GetComponent<Material>().color = Color.red;

        // recaliLight.color = Color.red;
        display_text.text = "";

        current_value = 0;
        int rnumber = Random.Range(0, 4);

        switch(rnumber)
        {
            case 0:
                correct_value = 25;
                break;

            case 1:
                correct_value = 50;
                break;

            case 2:
                correct_value = 75;
                break;

            case 3:
                correct_value = 100;
                break;

            default:
                correct_value = 0;
                break;

        }
        Debug.Log("correct " + correct_value);

    }

    public void TurnLeft ()
    {
        if(isQuestOn)
        {
            current_value = current_value - 25;
            AudioSource.PlayClipAtPoint(audioClips[0], Camera.main.transform.position, 0.25f);

            if(current_value < 0)
            {
                current_value = 100;
            }

            display_text.text = "" + current_value;


            if (current_value == correct_value)

            {
                QuestCompleted();
            }
        }

       
    }

    public void TurnRight ()
    {
        if(isQuestOn)
            {
            current_value = current_value + 25;
            AudioSource.PlayClipAtPoint(audioClips[0], Camera.main.transform.position, 0.15f);

            if (current_value > 100)
            {
                current_value = 0;
            }

            display_text.text = "" + current_value;

            if(current_value == correct_value)

            {
                QuestCompleted();
            }
        }

    }

    void QuestCompleted ()
    {
        recaliColor.GetComponent<Light>().color = Color.green;
        //   recaliLight = emission_color[0];
        AudioSource.PlayClipAtPoint(audioClips[1], Camera.main.transform.position, 0.15f);
        display_text.text = "";
        isQuestOn = false;
    }


}
