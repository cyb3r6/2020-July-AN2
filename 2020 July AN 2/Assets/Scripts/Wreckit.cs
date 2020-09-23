using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreckit : MonoBehaviour
{
    public Lever forwardBackwardLever, rightLeftLever;

    public float speed;

    private WreckingResetButton resetButton;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody wreckItRigidBody;
    [SerializeField]
    private Rigidbody wreckingBallRigidbody;
    private Vector3 startPositionWreckingBall;
    private Quaternion startRotationWreckingBall;

    private void Awake()
    {
        resetButton = FindObjectOfType<WreckingResetButton>();
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        wreckItRigidBody = GetComponent<Rigidbody>();

        startPositionWreckingBall = wreckingBallRigidbody.transform.position;
        startRotationWreckingBall = wreckingBallRigidbody.transform.rotation;

        resetButton.OnButtonPressed += ResetWreckIt;
    }

    void Update()
    {
        if(Mathf.Abs(forwardBackwardLever.NormalizedJointAngle()) > 0.05)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackwardLever.NormalizedJointAngle();
        }

        if (Mathf.Abs(rightLeftLever.NormalizedJointAngle()) > 0.05)
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightLeftLever.NormalizedJointAngle();
        }
    }

    public void ResetWreckIt()
    {
        // reset position and rotation
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        wreckingBallRigidbody.transform.position = startPositionWreckingBall;
        wreckingBallRigidbody.transform.rotation = startRotationWreckingBall;

        // turn the renderer on
        GetComponent<Renderer>().enabled = true;

        // stop cubes movment
        wreckItRigidBody.velocity = Vector3.zero;
        wreckItRigidBody.angularVelocity = Vector3.zero;
        wreckingBallRigidbody.velocity = Vector3.zero;
        wreckingBallRigidbody.angularVelocity = Vector3.zero;

    }
}
