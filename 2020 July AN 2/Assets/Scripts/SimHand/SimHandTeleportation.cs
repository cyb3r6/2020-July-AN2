using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandTeleportation : MonoBehaviour
{
    public Transform simHand;

    private LineRenderer teleportLine;
    private bool shouldTeleport;
    private Vector3 hitPosition;

    
    void Start()
    {
        teleportLine = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            RaycastHit hit;
            if(Physics.Raycast(this.transform.position, this.transform.forward, out hit))
            {
                hitPosition = hit.point;

                // line visuals
                teleportLine.SetPosition(0, transform.position);
                teleportLine.SetPosition(1, hitPosition);
                teleportLine.enabled = true;

                shouldTeleport = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            if(shouldTeleport == true)
            {
                // do the teleport!
                simHand.position = hitPosition;
                shouldTeleport = false;
                teleportLine.enabled = false;

            }
        }
    }

    // HOMEWORK: Figure out the offset for the sim hand vertical! (hint: use raycast)

}
