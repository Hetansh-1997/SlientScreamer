using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Animator myDoor = null;

    [SerializeField] bool openDoor = false;
    [SerializeField] bool closeDoor = false;

    void OnTriggerEvent(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openDoor)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }else if (closeDoor)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
