using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icom_Blink : MonoBehaviour{

    private float intesity;
    private Light iCom;
    public bool questWaiting = false;

    private void Start()
    {
        iCom = gameObject.GetComponent<Light>();
    }

     void Update()
    {
        //jos quest odottaa alkamistaan
        if (questWaiting)
        {
            intesity = Mathf.PingPong(Time.time * 3, 2);
            iCom.intensity = intesity;
        }
        else
        {
            iCom.intensity = 0;
        }
        
    }

}
