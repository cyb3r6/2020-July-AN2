using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    public float glitchRandomness = 0.1f;

    private Renderer glitchRenderer;
    private WaitForSeconds glitchDuration = new WaitForSeconds(0.1f);


    void Awake()
    {
        glitchRenderer = GetComponent<Renderer>(); 
    }

    private IEnumerator Start()
    {
        while (true)
        {
            float glitchTest = Random.Range(0f, 1f);
            if(glitchTest <= glitchRandomness)
            {
                StartCoroutine(GlitchMob());
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    private IEnumerator GlitchMob()
    {
        glitchDuration = new WaitForSeconds(Random.Range(0.5f, 0.25f));
        glitchRenderer.material.SetFloat("_Amount", 1f);
        glitchRenderer.material.SetFloat("_CutoutThresh", 0.3f);
        glitchRenderer.material.SetFloat("_Amplitude", Random.Range(100, 250));
        glitchRenderer.material.SetFloat("_Speed", Random.Range(1, 10));

        yield return glitchDuration;

        glitchRenderer.material.SetFloat("_Amount", 0f);
        glitchRenderer.material.SetFloat("_CutoutThresh", 0f);

    }
}
