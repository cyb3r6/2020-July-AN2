using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSimHand : GrabbableObjectSimHand
{
    public GameObject paintLinePrefab;
    private PaintbrushTip paintBrushTip;
    private GameObject spawnedPaint;

    
    void Awake()
    {
        paintBrushTip = GetComponentInChildren<PaintbrushTip>();
    }

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
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
