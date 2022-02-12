using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    Transform equipPosition;
    float distance = 10f;
    GameObject currentWeapon = null;
    GameObject wp;

    bool canGrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkWeapons();
        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                    drop();
                pickup();
            }
        }
        if (currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            { 
                    drop();
            }
        }
    }

    void checkWeapons()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "CanGrab")
            {
                Debug.Log("I can grab it!");
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        canGrab = false;
    }

    void pickup()
    {
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent=equipPosition;
        currentWeapon.transform.localEulerAngles=new Vector3(0f,180f,0f);
       // currentWeapon.GetComponent<Rigitbody>().isKinematic=true ;

    }
    void drop()
    {
        currentWeapon.transform.parent = null;
        //currentWeapon.GetComponent<Rigitbody>().isKinematic = false;
        currentWeapon = null;
    }

}
