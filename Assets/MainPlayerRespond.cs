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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respond(){
        source.clip = clips[1];
        source.Play();
    }
}
