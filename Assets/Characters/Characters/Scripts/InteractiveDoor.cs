using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : MonoBehaviour
{
    public GameObject Door;
    private Quaternion DoorOpen;
    private Quaternion DoorClosed;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider cube)
    {
        if (cube.tag == "Player")
            //DoorButton.SetActive(true);
            Debug.Log("button activated");
            DoorOpen = Door.transform.rotation = Quaternion.Euler(-90, 90, 0);
            DoorClosed = Door.transform.rotation;
            Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
            Debug.Log("Door Opened");
 
    }

        void OnTriggerExit(Collider cube)
    {}
    //     if (cube.tag == "Player")
    //         //DoorButton.SetActive(true);
    //         Debug.Log("button activated");
    //         DoorOpen = Door.transform.rotation = Quaternion.Euler(-90, 0, 0);
    //         DoorClosed = Door.transform.rotation;
    //         Door.transform.rotation = Quaternion.Lerp(DoorClosed, DoorOpen, Time.deltaTime * smooth);
    //         Debug.Log("Door Opened");
    // }
}
