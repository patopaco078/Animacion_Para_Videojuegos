using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class IKsurface : MonoBehaviour
{
    [SerializeField] private Transform detectionRef;
    [SerializeField] private Transform innerDetectionRef;
    [SerializeField] private float radius = 1.0f;
    [SerializeField] private LayerMask detectLayer;
    Vector3 NearSurface()
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
                return closestPoint;
               
            }

          
            Ray ray = new Ray(innerDetectionRef.position, detectionRef.position - innerDetectionRef.position);
            Physics.Raycast(ray, out RaycastHit hit, ray.direction.magnitude, detectLayer);
           
            return hit.point;
        }

        catch
        {
            return transform.position;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectionRef.position, radius);
        Gizmos.DrawLine(detectionRef.position, NearSurface());
    }

}
