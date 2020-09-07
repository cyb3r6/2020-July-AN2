using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVR : MonoBehaviour
{
    public GameObject pelletPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    private AudioSource gunSound;
    private GrabbableObjectVR grabbableObjectVR;
    private bool enable = false;

    void Start()
    {
        grabbableObjectVR = GetComponent<GrabbableObjectVR>();
        gunSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(grabbableObjectVR.isBeingHeld == true)
        {
            if(grabbableObjectVR.controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                Interaction();
            }
            if (grabbableObjectVR.controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    public void Interaction()
    {
        // do the shootin!
        GameObject temporaryPellet = Instantiate(pelletPrefab, spawnPoint.position, spawnPoint.rotation);
        temporaryPellet.GetComponent<Rigidbody>().AddForce(temporaryPellet.transform.forward * shootingForce);
        gunSound.Play();
        Destroy(temporaryPellet, 3);
    }
}
