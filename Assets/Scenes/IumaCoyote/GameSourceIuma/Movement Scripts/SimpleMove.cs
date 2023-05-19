using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

[Serializable]
public class UnityFloatEvent : UnityEvent<float>
{


}

public class SimpleMove : MonoBehaviour
{
   
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector2 inputValue;
    [SerializeField] private Vector2 smoothInput;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private UnityFloatEvent onMoved;

    public void Move(CallbackContext context)
    {
      
        inputValue = context.ReadValue<Vector2>();
        Debug.Log("mod");
      
    }

    private void Update()
    {
        smoothInput = Vector2.Lerp(smoothInput, inputValue, Time.deltaTime * acceleration);
        Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
        Vector3 rightVector = cameraTransform.right;
        Vector3 motionVector = forwardVector * smoothInput.y + rightVector * smoothInput.x;
        transform.Translate(motionVector * (Time.deltaTime * speed), Space.World);

        onMoved?.Invoke(smoothInput.magnitude / 1.414f);
        if(motionVector.magnitude>0.01)
        {
            transform.forward = motionVector.normalized;
        }

    }
}
