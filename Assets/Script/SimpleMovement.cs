using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;


[Serializable]
public class unityFloatEvent: UnityEvent<float>
{

}
public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Vector2 inputvalue;
    [SerializeField] private Vector2 smoothInput;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private unityFloatEvent onMoved;
    



    void Update()
    {
        smoothInput = Vector2.Lerp(smoothInput, inputvalue, Time.deltaTime * acceleration);
        
    }

    public void Move(UnityEngine.InputSystem.InputAction.CallbackContext context) 
    {
        inputvalue = context.ReadValue<Vector2>();
    }
}
