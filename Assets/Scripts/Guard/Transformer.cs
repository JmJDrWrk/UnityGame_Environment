using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{   
    public static GameObject SpecialObject;

    private bool isPlaying = false;
    public AudioSource sc;
    public AudioClip ad1;
    public AudioClip ad2;
    public AudioClip ad3;
    private GameObject lastColl;
    public bool Ataque;
    public Material enemyMat;
    public Material roberMat;
    public GameObject indicator;
    
    private bool showmsg = false;


    public int rutina;
    public float cronometro;
    //public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atacando;
    private bool sirenPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("SpecialObject");
        //target = null;
        // ani = GetComponent<Animator>();
        //target = GameObject.Find("Skeleton@Skin");
    }

    public void Comportamiento_Enemigo(){
        if(Vector3.Distance(transform.position, target.transform.position) > 5){
            //ani.SetBool("run", false);

            cronometro += 1 * Time.deltaTime;
            if(cronometro >=4){
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch(rutina){
                case 0:
                    //ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2: 
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    //ani.SetBool("walk", true);
                    break;
            }
        }else{
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

            if(!sirenPlaying && Ataque){
                sirenPlaying = true;
                sc.clip = ad3;
                gameObject.GetComponent<AudioSource>().Play();
                Invoke("turnDownSiren",2.5f);
            }
            //ani.SetBool("walk", false);
            //ani.SetBool("run", true);
            //ani.GetComponent<Animation>().wrapMode = WrapMode.PingPong;

            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player" && Ataque){
            HealthController.current_friend_health -= 90;  
            lastColl = other.gameObject;
            Debug.Log("PLAYING AUDIO");
        }

        if(other.tag == "Player" && !Ataque){
            showmsg = true;  
            lastColl = other.gameObject;
            sc.clip = ad1;
            sc.Play();

        }

    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player" && !Ataque){
          showmsg = false;  
        }
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();

        if(showmsg && Input.GetKeyDown(KeyCode.E)){
            gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * 50f);
            HealthController.current_money_health += 10;
            //Ataque = true; 
            Invoke("turnAtaqueOn",2); 
            indicator.GetComponent<MeshRenderer>().material = enemyMat;
            gameObject.GetComponent<Animation>().Play("celebration3");
            showmsg = false;
            target = lastColl;
            //AudioSource sc = gameObject.GetComponent<AudioSource>();
            if(!isPlaying){
                sc.clip = ad2;
                sc.Play();
                isPlaying = true;
            }
        }
        

        
    }

    private void OnGUI(){ 
        if(showmsg){
            string labelText = "Press E to steal money";
            GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }

    void turnDownSiren(){
        sirenPlaying = false;
    }

    void turnDownIsPlaying(){
        isPlaying = false;
    }

    void turnAtaqueOn(){
        Ataque = true;
    }
}