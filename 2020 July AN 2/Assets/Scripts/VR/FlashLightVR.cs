using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightVR : GrabbableObjectVR
{
    private Light flashLight;
    private bool enable;
    
    void Start()
    {
        flashLight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if(isBeingHeld == true)
        {
            if(controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                Interaction();
            }
            if (controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    public void Interaction()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
