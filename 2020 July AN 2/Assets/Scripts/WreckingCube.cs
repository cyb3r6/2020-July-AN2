using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    public WreckingResetButton resetButton;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody cubeRigidBody;

    void Awake()
    {
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        cubeRigidBody = GetComponent<Rigidbody>();

        // start listening to OnButtonPressed()
        // conditioning the cube to listen to OnButtonPressed
        resetButton.OnButtonPressed += ResetCubes;

    }    
    
    public void ResetCubes()
    {
        // reset position and rotation
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;

        // turn the renderer on
        GetComponent<Renderer>().enabled = true;

        // stop cubes movment
        cubeRigidBody.velocity = Vector3.zero;
        cubeRigidBody.angularVelocity = Vector3.zero;

        // reset score
        GameManager.instance.numberCubesDestroyed = 0;

    }
}
