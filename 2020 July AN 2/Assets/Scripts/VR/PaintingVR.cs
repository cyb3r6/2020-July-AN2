using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingVR : GrabbableObjectVR
{
    public GameObject paintLinePrefab;
    private PaintbrushTip paintBrushTip;
    private GameObject spawnedPaint;
    private bool enable;

    void Awake()
    {
        paintBrushTip = GetComponentInChildren<PaintbrushTip>();
    }

    
    void Update()
    {
        if (isBeingHeld)
        {
            if (controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                Interaction();
            }
            if (controller.triggerValue < 0.8f && enable)
            {
                enable = false;
                spawnedPaint.transform.position = spawnedPaint.transform.position;
                spawnedPaint = null;
            }

            if (spawnedPaint)
            {
                spawnedPaint.transform.position = paintBrushTip.transform.position;
            }
        }
    }

    private void Interaction()
    {
        spawnedPaint = Instantiate(paintLinePrefab, paintBrushTip.transform.position, paintBrushTip.transform.rotation);
        TrailRenderer paintTrail = spawnedPaint.GetComponent<TrailRenderer>();
        paintTrail.GetComponent<Renderer>().material = paintBrushTip.paint;
    }
}
