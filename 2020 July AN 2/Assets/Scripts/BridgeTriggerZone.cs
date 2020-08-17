using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerZone : MonoBehaviour
{
    public Animator bridgeAnimator;

    private void OnTriggerEnter(Collider theOtherGameObjectWeCollidedWith)
    {
        if(theOtherGameObjectWeCollidedWith.tag == "Player")
        {
            bridgeAnimator.SetTrigger("Raise");
        }
        
    }
}
