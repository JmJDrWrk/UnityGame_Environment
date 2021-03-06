using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthController : MonoBehaviour
{   
    public static bool lights_enabled = false;

    private bool summary = true;
    public static float timeLeft = 300f;

    //Collided Booleans 
    private GameObject current_cubata;
    private bool cubata_collided = false;

    private MeshRenderer mesh;

    private GameObject last_object;
    private bool car_collided = false;

    private bool friend_collided = false;

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
    public static float current_drink_health; // current HP
    int[] drink_health_position = new int[3] {10,10,15};
    public AudioClip drinkClip;

    //AMOR
    public static float current_love_health; // current HP
    int[] love_health_position = new int[3] {10,30,15};

    //AMISTAD
    public static float current_friend_health; // current HP
    int[] friend_health_position = new int[3] {10,50,15};

    //MONEY
    public static float current_money_health; // current HP
    int[] money_health_position = new int[3] {10,70,15};

    //TIEMPO
    int[] time_health_position = new int[3] {300,10,15};
    
    void Awake(){
        if(UICONTROLLER.first){SceneManager.LoadScene("UI");UICONTROLLER.first=false;}
    }

    void  Start(){   
        //GameObject.FindWithTag("Musica").GetComponent<AudioSource>().volume = 1;
        current_drink_health = 70f;
        current_love_health = 90f;
        current_friend_health = 90f;
        Invoke("revert_summary",10);
    }
   
   void revert_summary(){summary=false;}

    void Update()
    {
        if(lights_enabled){timeLeft -= Time.deltaTime;}

        if(Input.GetKeyDown(KeyCode.E)){
            if(cubata_collided){drink();}
            if(car_collided){car_car();}
            if(friend_collided){talk_friend();}
            
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Cubata"){ 
            cubata_collided = true;
            current_cubata = other.gameObject;
        }
        if(other.tag == "Coche"){
            car_collided = true;
            last_object = other.gameObject;
        }
        if(other.tag == "Amigo"){
            friend_collided = true;
            last_object = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Cubata"){ 
            cubata_collided = false;
        }
        if(other.tag == "Coche"){
            car_collided = false;
        }
        if(other.tag == "Amigo"){
            friend_collided = false;
        }
    }

    //CUBATA
    void drink(){
        cubata_collided = false;
        Rigidbody gameObjectsRigidBody = current_cubata.AddComponent<Rigidbody>();
        mesh = current_cubata.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        audioSource.clip = drinkClip;
        audioSource.Play();
        Invoke("launch",2);
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
        Rigidbody gameObjectsRigidBody = last_object.AddComponent<Rigidbody>();
        last_object.GetComponent<Rigidbody>().AddForce(spawnpoint.forward*500f);
    }
    

    //FRIENDS
     void talk_friend(){
        last_object.GetComponent<TalkScript>().talk();
     }


    

    //health
    void OnGUI(){
        string health_type;

        //SED
        health_type = "alcohol";
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
        GUI.Label(new Rect(posX + 300, posY, 100, 50), (int)(current_drink_health) + "/" + maxHP.ToString() + " " + health_type, HUDSkin);

        //AMOR
        health_type = "amor";
        posX = love_health_position[0];
        posY = love_health_position[1];
        height = love_health_position[2];
        percentage = healthBarWidth * (current_love_health/100f);

        GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       
        GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
       
        HUDSkin = new GUIStyle();
        //control_health(current_drink_health, percentage, current_drink_health);
        HUDSkin.normal.textColor = Color.green;
        HUDSkin.fontStyle = FontStyle.BoldAndItalic;
        HUDSkin.fontSize = 16;
        GUI.Label(new Rect(posX + 300, posY, 100, 50), (int)(current_love_health) + "/" + maxHP.ToString() + " " + health_type, HUDSkin);
        
        //AMISTAD
        health_type = "social";
        posX = friend_health_position[0];
        posY = friend_health_position[1];
        height = friend_health_position[2];
        percentage = healthBarWidth * (current_friend_health/100f);

        GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       
        GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
       
        HUDSkin = new GUIStyle();
        //control_health(current_drink_health, percentage, current_drink_health);
        HUDSkin.normal.textColor = Color.green;
        HUDSkin.fontStyle = FontStyle.BoldAndItalic;
        HUDSkin.fontSize = 16;
        GUI.Label(new Rect(posX + 300, posY, 100, 50), (int)(current_friend_health) + "/" + maxHP.ToString() + " " + health_type, HUDSkin);



        //MONEY
        health_type = "money";
        posX = money_health_position[0];
        posY = money_health_position[1];
        height = money_health_position[2];
        percentage = healthBarWidth * (current_money_health/100f);

        GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       
        GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
       
        HUDSkin = new GUIStyle();
        //control_health(current_drink_health, percentage, current_drink_health);
        HUDSkin.normal.textColor = Color.green;
        HUDSkin.fontStyle = FontStyle.BoldAndItalic;
        HUDSkin.fontSize = 16;
        GUI.Label(new Rect(posX + 300, posY, 100, 50), (int)(current_money_health) + "/" + maxHP.ToString() + " " + health_type, HUDSkin);


        //TIEMPO
        health_type = "tiempo";
        posX = time_health_position[0];
        posY = time_health_position[1];
        height = time_health_position[2];
        percentage = healthBarWidth * (timeLeft/100f);

        //GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       
        //GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
       
        HUDSkin = new GUIStyle();
        HUDSkin.normal.textColor = Color.green;
        HUDSkin.fontStyle = FontStyle.BoldAndItalic;
        HUDSkin.fontSize = 16;
        GUI.Label(new Rect(posX + 300, posY, 100, 50), (int)(timeLeft)+ "s" + health_type, HUDSkin);

        if(summary){
            string labelText = "Parece que ha habido un apag??n, encuentra la caja de fusibles para Party Rock";
            GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }

}
