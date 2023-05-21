using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class Snaper : MonoBehaviour
{

    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;
    [SerializeField] private float interpolacion = 1.0f;

    private float weight;

   
    public void UpdateWeights()
    {
        foreach(MultiParentConstraint animatedbone in animatedBones) 
        {
            animatedbone.weight = weight;
        }
        foreach(MultiParentConstraint proceduralbone in proceduralBones)
        {
            proceduralbone.weight = 1 - weight;
        }

    }
    public void SetWeights(bool state)
    {
        weight += Time.deltaTime * interpolacion * (state ? 1 : -1);
        weight = Mathf.Clamp01(weight);

        UpdateWeights();
    }

}
