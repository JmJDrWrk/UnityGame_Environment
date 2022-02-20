using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController cc;
    public float Velocidad=12;

    public float Gravedad = -9.81f;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool isGrounded;

    private Animator animator;
    private Animation anim;
    private bool animating = false;
    private bool isdrinking = false;
    private float oldvelocity;


    void Start(){
        anim = gameObject.GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {   
        oldvelocity = velocity.y;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        
        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(3 * -2 * Gravedad);
        }

        float x = Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");

        Vector3 move = transform.right * x+transform.forward*z;
        cc.Move(move*Velocidad*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && !animating)
        {   
            isdrinking = false;
            print("PLAYING ANIM 1");
            anim.Play();
            anim.wrapMode=WrapMode.PingPong;
            animating = true;
            
        }else if(Input.GetKeyDown(KeyCode.E) && !animating)      {
            isdrinking = true;
            print("PLAYING ANIM 2");
            anim.Play("drinkAnim");
            //anim.wrapMode=WrapMode.;
            animating = true;
            //yield return new WaitForSeconds(2);
            isdrinking = true;
            Invoke("setDrinkfalse",1);
            //move very slow
            
            
        }


        if (move == new Vector3(0, 0, 0) && !isdrinking){
            anim.wrapMode=WrapMode.Default;
            anim.Stop();
            animating = false;
            print("ANIMATING IS NOW FALSE");
        }

        print("TIEMPO: " + move);

        velocity.y += Gravedad * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

    }
    void setDrinkfalse(){
        isdrinking = false;
    }
}