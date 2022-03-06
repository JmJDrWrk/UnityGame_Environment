using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private bool showmsg = false;

    public GameObject LightsGO;

    void Update(){
        if(showmsg){
            if(Input.GetKeyDown(KeyCode.F)){
                activate();
                Debug.Log("Light--activate call");
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            showmsg = true;
           Debug.Log("Light--triggered enter");
        }
    }

    private Light[] lights;
    private AudioSource[] scs;
     // Use this for initialization
    void Start (){
         lights = FindObjectsOfType(typeof(Light)) as Light[];
         foreach(Light light in lights)
        {
            if(light.tag!="Independent"){
                light.intensity = 0;
                Debug.Log(light);
            }
        }

        scs = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
         foreach(AudioSource sc in scs)
        {
            if(sc.tag=="Speaker"){
                sc.volume = 0;
                Debug.Log(sc);
            }
        }
    }

     void activate () {
         lights = FindObjectsOfType(typeof(Light)) as Light[];
         foreach(Light light in lights)
        {
            if(light.tag!="Independent"){
                light.intensity = 1.5f;
                Debug.Log(light);
            }
        }

        scs = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
         foreach(AudioSource sc in scs)
        {   
            if(sc.tag=="Speaker"){
                sc.Play();
                sc.volume = 0.35f;
                Debug.Log(sc);
            }

            if(sc.tag=="Enemy"){
                sc.volume = 0.05f;
            }
        }

        HealthController.lights_enabled = true;
     }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
          showmsg = false;  
          Debug.Log("Light--triggered exit");
        }
    }

    private void OnGUI(){ 
        if(showmsg){
        Debug.Log("Light--gui");
        string labelText = "Press F to PartyRock";
        GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }
}
