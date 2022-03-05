using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public Transform canSpawn;
    public Transform can;
    private bool showmsg = false;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if((HealthController.current_money_health - 12) >0){
                showmsg = false;
                HealthController.current_money_health -=12;
                Instantiate(can, canSpawn.transform.position, Quaternion.identity);
            }else{
                showmsg = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            showmsg = false;

        }
    }

    void OnGUI(){
        if(showmsg){
            string labelText = "You need at least 12$ to buy a CocaLoca";
            GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }

    
}
