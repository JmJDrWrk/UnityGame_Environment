using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{   
    //Collided Booleans 
    private GameObject current_cubata;
    private bool cubata_collided = false;

    private MeshRenderer mesh;

    private GameObject current_car;
    private bool car_collided = false;

    //Spawnpoint
    public Transform spawnpoint;
    //AudioSource
    public AudioSource audioSource;
    
    //AJUSTES
    public Texture2D healthBackground; 
    public Texture2D healthForeground; 
    public Texture2D healthDamage;     
    public GUIStyle HUDSkin;    
    private float healthBarWidth = 100f;
    private float maxHP = 100f;    

    //SED
    private float initial_drink_health; //a value for reducing previous current health through attacks
    public static float current_drink_health; // current HP
    int[] drink_health_position = new int[3] {10,10,15};

    void Start()
    {   
        initial_drink_health = 100f;
        current_drink_health = 50f;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(cubata_collided){drink();}
            if(car_collided){car_car();}
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Cubata"){ 
            cubata_collided = true;
            current_cubata = other.gameObject;
        }
        if(other.tag == "Coche"){
            car_collided = true;
            current_car = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Cubata"){ 
            cubata_collided = false;
        }
        if(other.tag == "Coche"){
            car_collided = false;
        }
    }

    //CUBATA
    void drink(){
        cubata_collided = false;
        Rigidbody gameObjectsRigidBody = current_cubata.AddComponent<Rigidbody>();
        mesh = current_cubata.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        audioSource.Play();
        Invoke("launch",4);
    }

    void launch(){
        mesh.enabled = true;
        current_cubata.GetComponent<Rigidbody>().AddForce(spawnpoint.forward*500f);
        current_drink_health = current_drink_health + 10f;
        current_cubata.tag = "daemon";
        cubata_collided = false;
        Invoke("kill",3);
    }
    void kill(){
        Destroy(current_cubata);
    }
    //CAR
    void car_car(){
        Rigidbody gameObjectsRigidBody = current_car.AddComponent<Rigidbody>();
        current_car.GetComponent<Rigidbody>().AddForce(spawnpoint.forward*500f);
    }
    
    //health
    void OnGUI(){
        int posX = drink_health_position[0];
        int posY = drink_health_position[1];
        int height = drink_health_position[2];

        float percentage = healthBarWidth * (current_drink_health/100f);

        GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       
        GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
       
        HUDSkin = new GUIStyle();
        //control_health(current_drink_health, percentage, current_drink_health);
        HUDSkin.normal.textColor = Color.green;
        HUDSkin.fontStyle = FontStyle.BoldAndItalic;
        HUDSkin.fontSize = 16;
        GUI.Label(new Rect(30, 28, 100, 50), (int)(current_drink_health) + "/" + maxHP.ToString(), HUDSkin);
    }

    void control_health(float curHP, float percentage, float previousHealth){
        if(curHP == maxHP){
            HUDSkin.normal.textColor = Color.green;
            HUDSkin.fontStyle = FontStyle.BoldAndItalic;
            HUDSkin.fontSize = 16;
            GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);
           
        } else if(curHP < maxHP){
           
            if(percentage <= 50  || percentage >= 25){
                HUDSkin.normal.textColor = Color.yellow;
                HUDSkin.fontStyle = FontStyle.BoldAndItalic;
                HUDSkin.fontSize = 16;
                GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);
       
            } else if (percentage < 25){
                HUDSkin.normal.textColor = Color.red;
                HUDSkin.fontStyle = FontStyle.BoldAndItalic;
                HUDSkin.fontSize = 16;
                GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);
           
            } else {
                HUDSkin.normal.textColor = Color.white;
                HUDSkin.fontStyle = FontStyle.BoldAndItalic;
                HUDSkin.fontSize = 16;
                GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);
            }  
        }
    }
}
