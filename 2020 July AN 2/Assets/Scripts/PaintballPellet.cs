using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballPellet : MonoBehaviour
{
    public List<Material> ourPaints = new List<Material>();
    static private int paintIndex = 0;

    private void OnCollisionEnter(Collision Jonathan)
    {
        if(Jonathan.collider.tag == "Paintable")
        {
            // do the painting!
            Jonathan.collider.GetComponent<Renderer>().material = ourPaints[paintIndex];

            paintIndex++;

            if(paintIndex == ourPaints.Count)
            {
                paintIndex = 0;
            }

            // HOMEWORK: randomize the paintIndex!
        }
    }
}
