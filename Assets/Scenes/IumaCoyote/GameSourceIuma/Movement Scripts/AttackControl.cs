using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AttackControl : MonoBehaviour
{
    [SerializeField] private UnityEvent onAttack;

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.action.WasPerformedThisFrame())
        {
            Debug.Log("E");
            onAttack?.Invoke();

        }
    }
}
