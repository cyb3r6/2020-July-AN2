using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRInput controller;

    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    [Range(1, 100)]
    public float throwForce = 1f;

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

        #region Interaction Method 1

        if (controller.triggerValue > 0.8f && heldObject)
        {
            heldObject.BroadcastMessage("Interaction");
        }

        #endregion
    }

    private void Grab()
    {
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Release()
    {
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
