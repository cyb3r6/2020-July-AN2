using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRInput controller;

    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    private void OnTriggerEnter(Collider otherThingWeTouched)
    {
        collidingObject = otherThingWeTouched.gameObject;       // saving what we're touching
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)                 // checking we've exited the "collidingObject" and not some other
        {
            collidingObject = null;                             // we are no longer touching an object
        }
    }

    void Awake()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller.gripValue > 0.8f)
        {
            if (collidingObject)
            {
                heldObject = collidingObject;

                // do the grab!
                Grab();
            }
        }
        if (controller.gripValue < 0.8f)
        {
            if (heldObject)
            {
                Release();
            }
        }
    }

    private void Grab()
    {
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Release()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }
}
