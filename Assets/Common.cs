using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour {
    
    public static IEnumerator WaitForAPeriodOfSeconds(int randomTime)
    {
        yield return new WaitForSeconds(randomTime);
    }

    public static int GetRandomWaitTime()
    {
        return Random.Range(0, 30);
    }

    public static void ChangeCamera(Camera[] cameras)
    {
        foreach(Camera camera in cameras)
        {
            camera.enabled = !camera.enabled;
            camera.GetComponent<AudioListener>().enabled = !camera.GetComponent<AudioListener>().enabled;
        }
    }
}
