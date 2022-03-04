using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour
{   
    private GameObject lastPlayer;
    private AudioClip next_clip;
    private List<AudioClip> elapsed_clips;
    public List<AudioClip> clips;
    public AudioSource MyaudioSource;
    void Start(){}


    public void talk(){
        if(clips.Count == 0){
            clips=elapsed_clips;
            Debug.Log("Clips Reset");
        }

        int index = Random.Range(0, clips.Count-1);
        Debug.Log("Current Clip--> " + clips[index] + " -last Count- " + clips.Count);     
        Invoke("magia",1);
        MyaudioSource.clip = clips[index];
        MyaudioSource.Play();
    }

    void magia(){
        lastPlayer.GetComponent<MainPlayerRespond>().respond();
        Debug.Log("MAGIA");
        elapsed_clips.Add(next_clip);
        clips.Remove(next_clip);
        Debug.Log("Current Clip--> actual Count- " + clips.Count + " elapsed count " + elapsed_clips.Count);

    }

    void OnTriggerEnter(Collider other){
        lastPlayer = other.gameObject;
        Debug.Log("onTriggerEnter");
        if(other.tag == "Player"){
            Debug.Log("Player enter");
            talk();
            HealthController.current_friend_health +=10;
        }
    }

    void OnTriggerExit(Collider other){
        
    }

}
