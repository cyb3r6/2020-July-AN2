using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding
    public Transform snapPosition;

    private void OnTriggerEnter(Collider otherThingWeTouched)
    {
        collidingObject = otherThingWeTouched.gameObject;       // saving what we're touching
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)                 // checking we've exited the "collidingObject" and not some other
        {
            collidingObject = null;                             // we are no longer touching an object
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (collidingObject)
            {
                heldObject = collidingObject;

                // do the grab!
                Grab();                
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (heldObject)
            {
                Release();
            }
        }
    }

    private void Grab()
    {
        heldObject.transform.SetParent(snapPosition);
        heldObject.transform.localPosition = Vector3.zero;                  // (0,0,0)
        heldObject.transform.localRotation = Quaternion.identity;           // (0,0,0,0)

        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Release()
    {        
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }
}
