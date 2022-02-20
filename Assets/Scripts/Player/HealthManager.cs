using UnityEngine;
using System.Collections;
 
public class HealthManager : MonoBehaviour{
    //private bool animating = false;
    //private Animator animator;
    //private Animation anim;
    private GameObject collidedObject;
    private bool gabicollided;
    private bool cubatacollided;
    private bool epressed;
    public AudioSource audioSource;
    
    //SED
        public Texture2D healthBackground; 
        public Texture2D healthForeground; 
        public Texture2D healthDamage;     
        public GUIStyle HUDSkin;           
   
    //SED
        private float previousHealth; //a value for reducing previous current health through attacks
        private float healthBarWidth; //a value for creating the health bar size
        private float myFloat; // an empty float value to affect drainage speed
        public static float curHP; // current HP
        public static float maxHP; // maximum HP


    //AMOR
        private float love_previous_health; //a value for reducing previous current health through attacks
        public static float love_health; // current HP

        
                 
    void Start () {
        //last
            //curHP -= 0; // drain the current HP to test the health (Assign a value to drain the health)
            curHP = 10f;
            maxHP = 100f;
            previousHealth = maxHP; // assign the empty value to store the value of max health
            healthBarWidth = 100f; // create the health bar value
            myFloat = (maxHP / 100) * 10; // affects the health drainage
            //anim = gameObject.GetComponent<Animation>();
            //animator = gameObject.GetComponent<Animator>();

        //LOVE HEALTH
        love_previous_health = 100f;
        love_health = 10f;



    }
   
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            drink();
            if(gabicollided){talkgabi();}
            //anim.Play("drinkAnim");
            //anim.wrapMode=WrapMode.PingPong;
        }

        // if(Input.GetKeyDown(KeyCode.E) && !animating){
        //     print("PLAYING ANIM 2");
        //     anim.Play("drinkAnim");
        //     anim.wrapMode=WrapMode.PingPong;
        //     animating = true;
        // }
        adjustCurrentHealth();
    }

    void consume(){
        Destroy(collidedObject);
        //animating = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Puerta"){
            curHP -= 50f;
        }else if(other.tag == "Cubata"){
            cubatacollided = true;
            collidedObject = other.gameObject;
            //curHP = 100f;
        }else if(other.tag == "Gabi"){
            gabicollided = true;
            collidedObject = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.tag == "Cubata"){
            cubatacollided = false;
        }else if(other.tag == "Gabi"){
            gabicollided = false;
        }
    }
    void talkgabi(){
        //Destroy(collidedObject);
        //Make gabi speak
    }
    void drink(){
        if(cubatacollided){
            curHP += 10f;
            audioSource.Play();
            //anim.Play("drinkAnim");
            //anim.wrapMode=WrapMode.PingPong;
            //gameObject.GetComponent<Animation>().Play("drinkAnim");
            cubatacollided = false;
            consume();
        }
    }
    
    
    void OnGUI () {
        int posX = 10;
        int posY = 10;
        int height = 15;

        int posX2 = posX + 20;
        int posY2 = posY + 20;
        int height2 = height + 20;
               
        float previousAdjustValue = (previousHealth * healthBarWidth) / maxHP;
        float percentage = healthBarWidth * (curHP/maxHP);
               
        GUI.DrawTexture (new Rect (posX, posY, (healthBarWidth * 2), height), healthBackground);       
       
        GUI.DrawTexture (new Rect (posX, posY, (previousAdjustValue * 2), height), healthDamage);
       
        GUI.DrawTexture (new Rect (posX, posY, (percentage * 2), height), healthForeground);
       
        HUDSkin = new GUIStyle();
       
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

    public void adjustCurrentHealth(){
                       
        /**Deduct the current health value from its damage**/  
       
        if(previousHealth > curHP){
            previousHealth -= ((maxHP / curHP) * (myFloat)) * Time.deltaTime; // deducts health damage
        } else {
            previousHealth = curHP;
        }
       
        if(previousHealth < 0){
            previousHealth = 0;
        }
       
        if(curHP > maxHP){
            curHP = maxHP;
            previousHealth = maxHP;
        }
       
        if(curHP < 0){
            curHP = 0;
        }
    }
}
 
//csharp.referencesCodeLens.enabled 