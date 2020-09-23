using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Observer Pattern is better to use than the singleton pattern...
    public static GameManager instance;

    public int numberCubesDestroyed;

    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CountCubesDestroyed()
    {
        numberCubesDestroyed++; // numberCubesDestoryed + 1

    }
    
    
}
