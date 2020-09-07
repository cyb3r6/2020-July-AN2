using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collect all information from our controllers
/// Expose useful information.
/// </summary>

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;             // if true, left controller
    public float gripValue;
    public float triggerValue;

    private string gripAxis;
    private string triggerAxis;

    public Vector3 handVelocity;
    private Vector3 previousPosition;

    public Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;

    void Awake()
    {
        if (isLeftHand)                 // shorthand for isLeftHand == true
        {
            gripAxis = "LeftGrip";
            triggerAxis = "LeftTrigger";
        }
        else
        {
            gripAxis = "RightGrip";
            triggerAxis = "RightTrigger";
        }
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);

        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        handAngularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;
    }
}
