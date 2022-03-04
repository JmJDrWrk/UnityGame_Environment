using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyLight : MonoBehaviour
{
    void Update(){
        transform.Rotate(Vector3.right* 100f*Time.deltaTime);
    }
}
