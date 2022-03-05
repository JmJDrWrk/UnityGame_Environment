using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public Transform canSpawn;
    public Transform can;
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if((HealthController.current_money_health - 12) <0){
                HealthController.current_money_health -=12;
                Instantiate(can, canSpawn.transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerExit(Collider other){

    }


}
