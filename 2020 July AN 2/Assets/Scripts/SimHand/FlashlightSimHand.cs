using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSimHand : GrabbableObjectSimHand
{
    private Light flashLight;

    void Start()
    {
        flashLight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if(isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
            }
        }
    }

    private void Interaction()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
