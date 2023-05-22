using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Iumita
{
    public class AttackControl : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAttack1, onAttack2, onAttack3;


        public void Attack1(InputAction.CallbackContext context)
        {
            if (context.action.WasPerformedThisFrame())
            {
                Debug.Log("f");
                onAttack1?.Invoke();

            }
        }
        public void Attack2()
        {

            Debug.Log("q");
            onAttack2?.Invoke();

        }
        public void Attack3()
        {

            Debug.Log("e");
            onAttack3?.Invoke();

        }
    }
}

