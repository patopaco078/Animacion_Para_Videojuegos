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
    Rigidbody rb;
    [SerializeField] float jumpForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move(CallbackContext context)
    {
      
        inputValue = context.ReadValue<Vector2>();
        Debug.Log("move");
    }
    public void Jump(CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce);
        
    }
    private void Update()
    {
        smoothInput = Vector2.Lerp(smoothInput, inputValue, Time.deltaTime * acceleration);
        Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
        Vector3 rightVector = cameraTransform.right;
        Vector3 motionVector = forwardVector * smoothInput.y + rightVector * smoothInput.x;
        Vector2 twoMotionVector = motionVector;
        transform.Translate(twoMotionVector * (Time.deltaTime * speed), Space.World);
        if(inputValue==Vector2.zero)
        {
            smoothInput = Vector2.zero;
        }
        onMoved?.Invoke(smoothInput.magnitude);// /1.414f

        if (twoMotionVector.magnitude >0.01)
        {
            transform.forward = twoMotionVector.normalized;
        }

    }
}
