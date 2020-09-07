using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSimHand : MonoBehaviour
{
    public GameObject pelletPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    private AudioSource gunSound;
    private GrabbableObjectSimHand grabbableObjectSimHand;

    private void Start()
    {
        gunSound = GetComponent<AudioSource>();
        grabbableObjectSimHand = GetComponent<GrabbableObjectSimHand>();
    }
    void Update()
    {
        if(grabbableObjectSimHand.isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
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
