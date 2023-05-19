using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector2 inputValue;
    [SerializeField] private Vector2 smoothInput;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private UnityEvent onMoved;

    public void Move(CallbackContext context)
    {
        /* Vector2 inputValue = context.ReadValue<Vector2>();
         Vector3 newForward = Vector3.ProjectOnPlane(camera.transform.forward, transform.up);
         Vector3 newRight = camera.transform.right;
         transform.Translate(newForward * inputValue.y + newRight * inputValue.x);*/


        /* Vector2 motionValue = context.ReadValue<Vector2>();
         Debug.Log("move");
         transform.Translate(motionValue);*/
        inputValue = context.ReadValue<Vector2>();
      
    }

    private void Update()
    {
        smoothInput = Vector2.Lerp(smoothInput, inputValue, Time.deltaTime * acceleration);
        Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
        Vector3 rightVector = cameraTransform.right;
        Vector3 motionVector = forwardVector * smoothInput.y + rightVector * smoothInput.x;
        transform.Translate(motionVector * (Time.deltaTime * speed), Space.World);
        if(motionVector.magnitude>0.01)
        {
            transform.forward = motionVector.normalized;
        }

    }
}
