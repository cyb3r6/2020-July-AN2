using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandAnimator : MonoBehaviour
{
    private Animator simHandAnim;

    void Start()
    {
        simHandAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            simHandAnim.SetBool("IsClosing", true);     // closing the fist
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            simHandAnim.SetBool("IsClosing", false);    // opening the fist
        }
    }
}
