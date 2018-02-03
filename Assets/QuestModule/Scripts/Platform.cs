using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private static bool isDroneOnPlatform = true;

    public static bool IsDroneOnPlatform()
    {
        return isDroneOnPlatform;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Drone")
        {
            isDroneOnPlatform = true;
        }
    }
	
}
