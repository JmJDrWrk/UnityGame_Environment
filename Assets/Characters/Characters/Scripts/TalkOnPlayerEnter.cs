using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOnPlayerEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip ac1;
    public AudioClip ac2;
    private AudioClip[] audioclips;
    void Start(){
        audioclips[0] = ac1;
        audioclips[1] = ac2;
        audioSource.clip = ac1;
    }

    void OnTriggerEnter(Collider cube)
    {
        if (cube.tag == "Player"){
            audioSource.Play();
           // yield return new WaitForSeconds(audioSource.clip.length);
            if(audioSource.clip == ac1){audioSource.clip = ac2;}else{audioSource.clip = ac1;}
            audioSource.Play();
        }
    
    }
 

    void OnTriggerExit(Collider cube)
    {

    }
}
