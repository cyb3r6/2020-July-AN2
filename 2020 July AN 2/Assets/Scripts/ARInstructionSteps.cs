using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject initializeHeatCanvas;
    public GameObject saltWaterCanvas;

    private List<GameObject> instructionSteps = new List<GameObject>();
    private int currentStep = 0;
    private GameObject currentCanvas;


    public void TurnOnInitializeHeatCanvas()
    {
        mainMenuCanvas.SetActive(false);
        initializeHeatCanvas.SetActive(true);

        instructionSteps.Clear();

        for(int i = 0; i < initializeHeatCanvas.transform.childCount - 1; i++)
        {
            instructionSteps.Add(initializeHeatCanvas.transform.GetChild(i).gameObject);
            Debug.Log("the instuction steps are: " + instructionSteps[i]);
        }

        currentCanvas = initializeHeatCanvas;
    }

    public void TurnOnSaltWaterCanvas()
    {
        mainMenuCanvas.SetActive(false);
        saltWaterCanvas.SetActive(true);

        instructionSteps.Clear();

        for (int i = 0; i < saltWaterCanvas.transform.childCount - 1; i++)
        {
            instructionSteps.Add(saltWaterCanvas.transform.GetChild(i).gameObject);
        }

        currentCanvas = saltWaterCanvas;
    }

    public void NextStep()
    {
        instructionSteps[currentStep].SetActive(false);

        if(currentStep == instructionSteps.Count-1)
        {
            currentStep = 0;
            instructionSteps[currentStep].SetActive(true);
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        instructionSteps[++currentStep].SetActive(true);
    }

    // HOMEWORK!
    public void PreviousStep()
    {

    }
}
