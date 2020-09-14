using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform button, downTransform;
    public AudioSource audioSource;
    private Vector3 upPosition;

    
    void Awake()
    {
        upPosition = button.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = downTransform.position;

            // TODO: do something with button?
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.position = upPosition;
        }        
    }
}
