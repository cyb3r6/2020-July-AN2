using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreckit : MonoBehaviour
{
    public Lever forwardBackwardLever, rightLeftLever;

    public float speed;

   
    void Update()
    {
        if(Mathf.Abs(forwardBackwardLever.NormalizedJointAngle()) > 0.05)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackwardLever.NormalizedJointAngle();
        }

        if (Mathf.Abs(rightLeftLever.NormalizedJointAngle()) > 0.05)
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightLeftLever.NormalizedJointAngle();
        }
    }
}
