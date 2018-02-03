using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class Random_Effects : MonoBehaviour{

    int randomNumber;
    private bool creepyShit = false;
    private PostProcessingBehaviour behaviour;
    private PostProcessingProfile originalProfile;
    private PostProcessingProfile grainProfile;

    public AudioClip[] audioClips;
    public Transform[] randomAudioSources;

    public AudioSource grainAudioSource;
    public AudioSource radioSource;

    private void Start()
    {
        randomNumber = Random.Range(90, 135);
        Debug.Log(randomNumber + "randomtime");

        behaviour = GameObject.Find("FirstPersonCharacter").GetComponent<PostProcessingBehaviour>();
        originalProfile = GameObject.Find("FirstPersonCharacter").GetComponent<PostProcessingBehaviour>().profile;
        grainProfile = Instantiate(behaviour.profile);

        

        grainAudioSource = gameObject.GetComponent<AudioSource>();
        radioSource = GameObject.Find("radio").GetComponent<AudioSource>();

        
   
    }

    private void Update()
    {
        if(randomNumber <= Time.time && creepyShit == false)
        {
            //määräaika ohi, voi alkaa randomefektit
            StartCoroutine(CreepyEffects());
           
        }

    }

    IEnumerator GrainEffect ()
    {
        yield return new WaitForSeconds(1);     //testiä

        Debug.Log("grainviesti");
        int maxRandom = Random.Range(3, 6);
        behaviour.profile = grainProfile;
        grainProfile.grain.enabled = true;
        grainAudioSource.volume = 0.3f;

        for (int i = 0; i < maxRandom; i++)
        {
            float randomTime = Random.Range(0.1f, 0.9f);
           
            //ääniefekti
            yield return new WaitForSeconds(randomTime);
            grainProfile.grain.enabled = false;
            grainAudioSource.volume = 0;
            yield return new WaitForSeconds(randomTime / 2);
            grainProfile.grain.enabled = true;
            grainAudioSource.volume = 0.3f;
            // behaviour.profile = originalProfile;
            Debug.Log("viesti");
        }
        behaviour.profile = originalProfile;
        grainAudioSource.volume = 0;
          
    }


    IEnumerator RadioDisturbance ()
    {

        yield return new WaitForSeconds(5);
        
        //vaihda klippi
        //toista klippi loppuun
        //vaihda takaisin klippi
        radioSource.clip = audioClips[0];
        radioSource.Play();
        yield return new WaitForSeconds(14.7f);

        radioSource.clip = audioClips[1];
        radioSource.Play();

    }

    void MetalBang ()
    {
        int randomNumber = Random.Range(0, randomAudioSources.Length);

        AudioSource.PlayClipAtPoint(audioClips[2], randomAudioSources[randomNumber].transform.position, 0.05f);
        
    }

    IEnumerator CreepyEffects ()
    {
        creepyShit = true;

        for (int i = 0; i < 100; i++)
        {
            int rNumber = Random.Range(25, 55);
            int rNumber2 = Random.Range(0, 3);

            switch(rNumber2)
            {
                case 0:
                        StartCoroutine(GrainEffect());
                        break;

                case 1:
                        StartCoroutine(RadioDisturbance());
                        break;

                case 2:
                        MetalBang();
                        break;

                case 3:
                        //neljäs event;
                        break;

                default:    //joku event
                             break;
                 
            }


            yield return new WaitForSeconds(rNumber);

            //tee jokin creepy shit, aloita loop uudestaan
        }



    }

}
