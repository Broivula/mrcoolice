using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_text_scroller : MonoBehaviour {

    private Text nameText;
    private Text dialogText;
    

    public AudioClip[] textAudio;


    private void Start()
    {
        nameText = GameObject.Find("Name_text").GetComponent<Text>();
        dialogText = GameObject.Find("Dialogue_text").GetComponent<Text>();


      //  StartCoroutine(TextScroller("Jaakko", "älkää tulko unitylle huomenna hehheh tässä nyt vähän tämmöstä huulta heitetään niin joo, katellaan kuka nauraa huomenna hehh",0));
    }

    public IEnumerator TextScroller (string name, string dialogue, int clip)
    {

        string d = "";
        int laskuri = 0;
        nameText.text = "" + name;

        foreach (char letter in dialogue)
            {
            //pistä char näytölle
            //play a sound
                 laskuri = laskuri + 1;
                 d = d + letter;
                 dialogText.text = "" + d;
                if(laskuri % 4 == 0)
                 AudioSource.PlayClipAtPoint(textAudio[clip], Camera.main.transform.position, 0.2f);
                 yield return new WaitForSeconds(0.001f);
            }

        
    }
}
