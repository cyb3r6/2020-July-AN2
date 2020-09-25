using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayToolVR : GrabbableObjectVR
{
    private XRayableItem[] xrayableItems;
    private bool enable;

    void Start()
    {
        xrayableItems = FindObjectsOfType<XRayableItem>();
    }

    
    void Update()
    {
        if (isBeingHeld)
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
        foreach(var item in xrayableItems)
        {
            item.ChangeRenderQueue();
        }
    }
}
