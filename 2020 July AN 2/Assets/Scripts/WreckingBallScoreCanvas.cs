using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WreckingBallScoreCanvas : MonoBehaviour
{
    public Text canvasText;

    void Update()
    {
        canvasText.text = "You've murderer: " + GameManager.instance.numberCubesDestroyed.ToString() + " cubes";
    }
}
