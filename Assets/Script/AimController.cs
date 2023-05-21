using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimController : MonoBehaviour
{
    [SerializeField] private Vector3 relativeDetectPos;
    [SerializeField] private float detectRadius;
    [SerializeField] private float stopLookDistance;
    [SerializeField] private LayerMask detectionMask;

    [SerializeField] private MultiAimConstraint aim;

    private void FixedUpdate()
    {
        Collider[] detected = Physics.OverlapSphere(transform.TransformPoint(relativeDetectPos), detectRadius, detectionMask);

        if (detected.Length > 0)
        {
            Transform target = detected[0].transform;
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= stopLookDistance)
            {
                aim.weight = 1;
                aim.data.sourceObjects.Clear();
                aim.data.sourceObjects.Add(new WeightedTransform(target, 1));
            }
            else
            {
                aim.weight = 0;
                aim.data.sourceObjects.Clear();
            }
        }
        else
        {
            aim.weight = 0;
            aim.data.sourceObjects.Clear();
        }
    }

}
