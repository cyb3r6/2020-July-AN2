using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    public Transform vrRig;

    private VRInput controller;
    private LineRenderer teleportLine;
    private bool shouldTeleport;
    private Vector3 hitPosition;

    
    void Start()
    {
        teleportLine = GetComponent<LineRenderer>();
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if (controller)
        {
            if (controller.isThumbstickPressed)
            {
                RaycastHit hit;
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
                {
                    hitPosition = hit.point;

                    // line visuals
                    teleportLine.SetPosition(0, transform.position);
                    teleportLine.SetPosition(1, hitPosition);
                    teleportLine.enabled = true;

                    shouldTeleport = true;
                }
            }
            if (controller.isThumbstickPressed == false)
            {
                if (shouldTeleport == true)
                {
                    // do the teleport!
                    vrRig.position = hitPosition;
                    shouldTeleport = false;
                    teleportLine.enabled = false;
                }
            }
        }
    }
}
