using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayableItem : MonoBehaviour
{
    public int originalRenderQueue;
    private bool changed;

    void Start()
    {
         originalRenderQueue = GetComponent<Renderer>().material.renderQueue;
    }

    public void ChangeRenderQueue()
    {
        changed = !changed;

        if(changed == true)
        {
            if (GetComponent<Renderer>())
            {                
                GetComponent<Renderer>().material.renderQueue = 3002;
            }
        }
        else
        {
            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().material.renderQueue = originalRenderQueue;
            }
        }
    }
}
