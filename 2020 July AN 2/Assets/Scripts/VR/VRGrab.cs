using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    [HideInInspector] 
    public VRInput controller;

    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    [Range(1, 100)]
    public float throwForce = 1f;

    private bool gripHeld;

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
        if(controller.gripValue > 0.8f && gripHeld == false)
        {
            gripHeld = true;

            if (collidingObject)
            {
                heldObject = collidingObject;

                // do the grab!
                Grab();
            }
        }
        if (controller.gripValue < 0.8f && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                Release();
            }
        }

        #region Interaction Method 1

        //if (controller.triggerValue > 0.8f && heldObject)
        //{
        //    heldObject.BroadcastMessage("Interaction");
        //}

        #endregion
    }

    private void Grab()
    {
        Debug.Log("Grab has been called!");

        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        #region Interaction Method 2

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.controller = controller;
            grabbable.isBeingHeld = true;
        }

        #endregion
    }

    private void Release()
    {

        #region Interaction Method 2

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.controller = null;
            grabbable.isBeingHeld = false;
        }

        #endregion

        // throw
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.velocity = controller.handVelocity * throwForce;
        rb.angularVelocity = controller.handAngularVelocity * throwForce;

        // reset held object
        heldObject.transform.SetParent(null);
        rb.isKinematic = false;
        heldObject = null;
    }
}
