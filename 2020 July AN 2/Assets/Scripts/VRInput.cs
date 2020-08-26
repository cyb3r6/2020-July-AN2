using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;             // if true, left controller
    public float gripValue;

    private string gripAxis;    
    
    void Awake()
    {
        if (isLeftHand)                 // shorthand for isLeftHand == true
        {
            gripAxis = "LeftGrip";
        }
        else
        {
            gripAxis = "RightGrip";
        }
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
    }
}
