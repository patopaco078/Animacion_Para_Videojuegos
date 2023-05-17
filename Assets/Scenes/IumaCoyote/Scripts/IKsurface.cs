using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

[Serializable]
public class BoolUnityEvent: UnityEvent<bool>
    {

    }


public class IKsurface : MonoBehaviour
{
    [SerializeField] private Transform detectionRef;
    [SerializeField] private Transform innerDetectionRef;
    [SerializeField] private float radius = 1.0f;
    [SerializeField] private LayerMask detectLayer;
    public BoolUnityEvent OnDetected;
    bool NearSurface(out Vector3 nearestPoint)
    {
        try
        {
            Collider[] objectsInRange = Physics.OverlapSphere(detectionRef.position, radius, detectLayer);
            Vector3[] closestPoints = new Vector3[objectsInRange.Length];
            for (int i = 0; 1 < objectsInRange.Length; i++)
            {
                closestPoints[i] = objectsInRange[i].ClosestPoint(detectionRef.position);
            }
            Vector3 closestPoint = closestPoints.OrderBy(vector => Vector3.Distance(vector, detectionRef.position)).First();
            if (closestPoint != detectionRef.position)
            {
                nearestPoint = closestPoint;
               
               
            }
            else
            {
                Ray ray = new Ray(innerDetectionRef.position, detectionRef.position - innerDetectionRef.position);
                Physics.Raycast(ray, out RaycastHit hit, ray.direction.magnitude, detectLayer);
                nearestPoint = hit.point;
            }



            return true;
        }

        catch
        {
            nearestPoint = transform.position;
            return false;
            
        }

    }
    private void FixedUpdate()
    {
        Vector3 foundPoint = Vector3.zero;
        if(NearSurface(out foundPoint))
        {
            transform.position = foundPoint;
            OnDetected?.Invoke(true);
        }
        else
        {
            OnDetected?.Invoke(false);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectionRef.position, radius);
        //Gizmos.DrawLine(detectionRef.position, NearSurface());
    }
#endif

}
