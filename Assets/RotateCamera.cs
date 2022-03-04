using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        transform.Rotate(Vector3.up* 20f*Time.deltaTime);
    }
}
