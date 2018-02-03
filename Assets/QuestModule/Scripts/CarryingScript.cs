using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryingScript : MonoBehaviour {

    GameObject mainCamera;
    private bool carrying = false;
    private Transform spawnPoint;
    private GameObject carriedObject;
    public Recali_quest recaliQuest;

    public int distance;
    public float smooth;
    public GameObject [] drones;


	// Use this for initialization
	void Start ()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoint = GameObject.Find("Spawn_Point").GetComponent<Transform>();
        recaliQuest = GameObject.Find("GameController").GetComponent<Recali_quest>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (carrying)
        {
            Carry(carriedObject);
            CheckDrop();
        }
        else
        {

            Pickup();
        }
        
	}

    void Carry(GameObject o)
    {
        //kanna drone
        o.GetComponent<Rigidbody>().isKinematic = true;
        o.GetComponent<BoxCollider>().enabled = false;
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }
    
    void SpawnDrone (int i)
    {
        if(i == 0)
        {
            //spawnaa supply drone
            GameObject sdrone;
            sdrone = Instantiate(drones[0], spawnPoint) as GameObject;
            sdrone.transform.SetParent(GameObject.Find("house").GetComponent<Transform>());
            carriedObject = sdrone;
            carrying = true;
            Carry(sdrone);
        }
        else if (i == 1)
        {
            // spawnaa weapon drone
            GameObject wdrone;
            wdrone = Instantiate(drones[1], spawnPoint) as GameObject;
            wdrone.transform.SetParent(GameObject.Find("house").GetComponent<Transform>());
            carriedObject = wdrone;
            carrying = true;
            Carry(wdrone);
        }
        
    }

    void Pickup ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //ammu raycast
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Weapon_Drones" && hit.distance < 1.5f)
                {
                    //spawnaa weapon drone käsiin
                    SpawnDrone(1);
                }
                else if (hit.collider.gameObject.tag == "Supply_Drones" && hit.distance < 1.5f)
                {
                    //spawnaa supply drone käsiin
                    SpawnDrone(0);
                    
                }
                else if (hit.collider.gameObject.tag == "sdrone" && hit.distance < 2f || hit.collider.gameObject.tag == "wdrone" && hit.distance < 2f)
                {
                    carriedObject = hit.collider.gameObject;
                    Carry(hit.collider.gameObject);
                    carrying = true;
                }

                else if (hit.collider.gameObject.tag == "Left_monitor" && hit.distance < 2.5f && recaliQuest.isQuestOn == true)
                {
                    recaliQuest.TurnLeft();
                }
                else if (hit.collider.gameObject.tag == "Right_monitor" && hit.distance < 2.5f && recaliQuest.isQuestOn == true)
                {
                    recaliQuest.TurnRight();
                }

            }
        }
    }

    void CheckDrop ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //droppaa kannetun objektin
            StopCarrying();
        }
    }

    void StopCarrying()
    {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject.GetComponent<BoxCollider>().enabled = true;
        carriedObject = null;

    }
}
