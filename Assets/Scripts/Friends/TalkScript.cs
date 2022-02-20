using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkScript : MonoBehaviour
{
    private AudioSource audioSource;
    void Start(){audioSource = gameObject.GetComponent<AudioSource>();}
    public void talk(){audioSource.Play();}
}
