using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robame : MonoBehaviour
{   
    
    private bool showmsg = false;
    void Start()
    {   
        
    }


    void Update()
    {
        if(showmsg && Input.GetKeyDown(KeyCode.W)){
            gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 500f);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
          showmsg = true;  
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
          showmsg = false;  
        }
    }

    private void OnGUI(){ 
        if(showmsg){
        string labelText = "Press E to steal money";
        GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }
}
