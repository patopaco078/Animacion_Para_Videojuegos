using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class AnimationControlle : MonoBehaviour
{
   public void SetMotionValue(float value)
    {
        GetComponent<Animator>().SetFloat("MoveSpeed", value);
    }
}
