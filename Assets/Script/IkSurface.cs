using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

[Serializable]
public class BoolUnityEvent : UnityEvent<bool>
{

}

public class IkSurface : MonoBehaviour
{
    [SerializeField] private Transform detectionReference;
    [SerializeField] private Transform innerDetectionReference;
    [SerializeField] private float radius=1.0f;
    [SerializeField] private LayerMask detectionlayers;
    [SerializeField] BoolUnityEvent ondetected;
    bool Encontrarpunto(out Vector3 nearestpoint)
    {
        try 
        { 
        Collider[] objectsinrange = Physics.OverlapSphere(detectionReference.position, radius, detectionlayers);

        Vector3[] closestpoints = new Vector3[objectsinrange.Length];

        for(int i=0;i < objectsinrange.Length; i++ )
        {
            closestpoints[i] = objectsinrange[i].ClosestPoint(detectionReference.position);
        }

        Vector3 closestpoint = closestpoints.OrderBy(vector => Vector3.Distance(vector, detectionReference.position)).First();
        if (closestpoint != detectionReference.position)
           nearestpoint = closestpoint;
            else 
            {
                Ray r = new Ray(innerDetectionReference.position, detectionReference.position - innerDetectionReference.position);

                Physics.Raycast(r, out RaycastHit hit, r.direction.magnitude, detectionlayers);
                nearestpoint = hit.point;
            }

        

        return true;

        }
        catch 
        {
            nearestpoint = transform.position;
            return false;

        }
    }

    private void FixedUpdate()
    {
        Vector3 foundpoint = Vector3.zero;

        if(Encontrarpunto(out foundpoint))
        {

            transform.position = foundpoint;
            ondetected?.Invoke(true);
        }
        else
        {
            ondetected?.Invoke(false);
        }    
    }


#if UNYTY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectionReference.position, radius);
        Gizmos.DrawLine(detectionReference.position, Encontrarpunto());
    }

#endif
}
