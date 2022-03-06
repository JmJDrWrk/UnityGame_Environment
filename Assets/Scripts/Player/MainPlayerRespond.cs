using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerRespond : MonoBehaviour
{   
    private AudioSource source;
    public AudioClip[] clips;


    // Start is called before the first frame update
    void Start()
    {   
        source = gameObject.GetComponent<AudioSource>();
        source.clip = clips[0];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respond(){
        HealthController.current_friend_health += 10;
        source.clip = clips[Random.Range(0, clips.Length-1)];
        source.Play();
    }
}
