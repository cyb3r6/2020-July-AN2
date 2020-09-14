using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedButton : MonoBehaviour
{
    public Animator buttonAnim;

    // using Unity Events
    public UnityEvent buttonPressedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");
            buttonPressedEvent?.Invoke();
        }
    }

}
