using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWater : MonoBehaviour
{
    public PaintbrushTip paintbrush;
    private Material originalPaintBrushMaterial;
    
    void Start()
    {
        originalPaintBrushMaterial = paintbrush.GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PaintbrushTip>())
        {
            other.GetComponent<Renderer>().material = originalPaintBrushMaterial;
        }
    }
}
