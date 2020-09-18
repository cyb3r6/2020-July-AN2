using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Rigidbody leverRigidbody;
    public Vector3 centerOfMass = new Vector3(0, 0, 0);
    public HingeJoint myJoint;
    
    void Awake()
    {
        leverRigidbody = GetComponent<Rigidbody>();
        leverRigidbody.centerOfMass = centerOfMass;
    }

    public float NormalizedJointAngle()
    {
        float theta = myJoint.angle / myJoint.limits.max;
        return theta;
    }
}
