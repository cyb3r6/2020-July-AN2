using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCubeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WreckingCube")
        {
            other.GetComponent<Renderer>().enabled = false;
        }
    }
}
