using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKSnap : MonoBehaviour
{
    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;

    private float weight;

    private void UpdateWeights()
    {
       foreach(MultiParentConstraint animatedBone in animatedBones)
        {
            animatedBone.weight = weight;
        }
       foreach (MultiParentConstraint proceduralBone in proceduralBones)
        {
            proceduralBone.weight = 1 - weight;
        }
    }

    public void SetWeight(bool state)
    {
        weight = state ? 1 : 0;
        UpdateWeights();
    }
}
