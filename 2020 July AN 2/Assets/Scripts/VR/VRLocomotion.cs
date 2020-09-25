using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    [Tooltip("This is either the controller or head to show player forward directions")]
    public Transform director;
    public Transform vrRig;

    private VRInput controller;
    private Vector3 playerForward;
    private Vector3 playerRight;

    
    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        playerForward = director.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        playerRight = director.right;
        playerRight.y = 0f;
        playerRight.Normalize();

        // do the translational movement;
        vrRig.Translate(playerForward * controller.thumbstick.y * Time.deltaTime);
        vrRig.Translate(playerRight * controller.thumbstick.x * Time.deltaTime);

    }
}
