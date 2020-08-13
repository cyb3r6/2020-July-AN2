using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Rigidbody frankieRigidBody;
    public Vector3 location;
    public float moveSpeed;
    public float turnSpeed;
    public float sprint;
    void Start()
    {
        
    }

    
    void Update()
    {
        #region translational movement

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= sprint;
            Babushka();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= sprint;
        }

        // HOMEWORK: Jump!

        #endregion

        #region rotation using the keyboard

        // rotation using keyboard

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        //}
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
        //}
        //if (Input.GetKey(KeyCode.C))
        //{
        //    transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed);
        //}

        #endregion

        #region rotation using mouse

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.Self);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse Y") * turnSpeed, Space.Self);

        #endregion

    }

    public void Babushka()
    {
        Debug.Log("BABA YAGA");
    }
}

