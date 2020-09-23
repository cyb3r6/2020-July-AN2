using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WreckingResetButton : MonoBehaviour
{
    public Animator buttonAnim;

    // using Unity Events
    public UnityEvent buttonPressedEvent;

    public delegate void ButtonPressedEvent(); // subscribing methods to this variable (tuning fork)
    public ButtonPressedEvent OnButtonPressed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");
            buttonPressedEvent?.Invoke();

            OnButtonPressed();
        }
    }

}
