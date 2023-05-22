using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Iumita
{
    public class IKSnap : MonoBehaviour
    {
        [SerializeField] private MultiParentConstraint[] animatedBones;
        [SerializeField] private MultiParentConstraint[] proceduralBones;
        [SerializeField] private float interpoleichon = 1.0f;

        private float weight;

        private void UpdateWeights()
        {
            foreach (MultiParentConstraint animatedBone in animatedBones)
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
            weight += Time.deltaTime * interpoleichon * (state ? 1 : -1);
            weight = Mathf.Clamp01(weight);
            UpdateWeights();
        }
    }
}

