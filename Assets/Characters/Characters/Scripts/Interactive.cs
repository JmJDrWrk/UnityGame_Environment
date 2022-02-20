using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{

    private bool showmsg = false;
    private string labelText = "";
    private string displayText = "";
    void Start()
    {   
        //Set the tag of this GameObject to Player
        gameObject.tag = "Player";
    }
    private void  OnGUI(){ 
        
        if(showmsg){
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 20), displayText);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        //print("COJONES");
        if (other.tag == "Cubata"){
            print("Otro cubata loco para el vikila");
            labelText = "Otro cubata loco para el vikila!";
            displayText = "Press E to Drink";
            showmsg = true;
        }else if(other.tag == "Altavoz"){
            print("Otro altavoz loco para el vikila");
            labelText = "Otro altavoz loco para el vikila";
            displayText = "Press E to turn off the speaker";
            showmsg = true;
            //Get speaker object turn down the music
            //Get speaker object and change song
        }else if(other.tag == "Puerta"){
            print("Otro altavoz loco para el vikila");
            labelText = "Otro altavoz loco para el vikila";
            displayText = "Press E to open the door";
            showmsg = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        //print("COJONES");
        if (other.tag == "Cubata"){             showmsg = false;}
        else if(other.tag == "Altavoz"){        showmsg = false;}
        else if(other.tag == "Puerta"){         showmsg = false;}
    }

}


// public class playerScript : MonoBehaviour {
 
//     public GameObject DoorButton;
//     public GameObject Door;
//     public float smooth;
 
//     private Quaternion DoorOpen;
//     private Quaternion DoorClosed;
 
//     void Start() {
 
//         Door = GameObject.Find("Object001");
//         DoorButton = GameObject.Find("DoorButton");
//         DoorButton.SetActive(false);
//     }
 
//     void OnTriggerEnter(Collider cube)
//     {
 
//         if (cube.tag == "DoorButton")
//             DoorButton.SetActive(true);
//             Debug.Log("button activated");
 
//             DoorOpen = Door.transform.rotation = Quaternion.Euler(0, -90, 0);
//             DoorClosed = Door.transform.rotation;
 
//             Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
//             Debug.Log("Door Opened");
//     }