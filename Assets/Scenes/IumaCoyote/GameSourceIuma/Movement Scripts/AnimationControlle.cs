using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]

public class AnimationControlle : MonoBehaviour
{
    Animator animator;
    bool isIdle;
    Rigidbody rb;
    bool isGrounded;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        animator.SetFloat("verticalSpeed", rb.velocity.y);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
        }
    }
    public void SetMotionValue(float value)
    {
        animator.SetFloat("MoveSpeed", value);
        if(value<=0.1f&&!isIdle)
        {
            isIdle = true;
            StartCoroutine(SetBreak());
        }
        if(isIdle&&value>0.1f)
        {
            StopAllCoroutines();
            isIdle = false;
        }
    }
 
    IEnumerator SetBreak()
    {
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("break");
        isIdle = false;
    }
   
}
