using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public int finalAngle;
    private GameObject Door;
    private Quaternion DoorOpen;
    private Quaternion DoorClosed;
    private float smooth;
    // Start is called before the first frame update
    void Start()
    {
        Door = gameObject;
        smooth = 1000f;
    }

    private bool isCol = false;

    void OnTriggerEnter(Collider cube)
    {
        if (cube.tag == "Player"){

            isCol = true;
            if(HealthController.lights_enabled){
                //DoorButton.SetActive(true);
                Debug.Log("button activated");
                Debug.Log("door tag is " + Door.tag);
                DoorOpen = Door.transform.rotation = Quaternion.Euler(-90, 90, finalAngle);
                Debug.Log("door tag is quaternion " + DoorOpen);
                DoorClosed = Door.transform.rotation;
                Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
                Debug.Log("Door Opened");
                
            }
        }

 
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            isCol = false;
        }
    }

    void OnGUI(){
        if(!HealthController.lights_enabled && isCol){
            string labelText = "You must party Rock First\n Find the electrical box first";
            GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }



}
