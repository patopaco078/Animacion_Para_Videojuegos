using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator anim;

    private bool isGrounded;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 5f;

    public float timer;
    public float inicial;
    private bool quieto;
    Vector3 posicion;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
  

        if(isGrounded==false)
        {
            anim.SetBool("Saltando", true);
        }
        else 
        {
            anim.SetBool("Saltando", false);
        }
        /*if (isGrounded == true) Debug.Log("c puede");
        if (isGrounded == false) Debug.Log("no c puede");*/
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            
            rb.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);          
            isGrounded = false; // fix in place jump (velocity zero)
        }
       
    }

    public void Run (InputAction.CallbackContext context) 
    {
        

    }
    public void Move(InputAction.CallbackContext context)
    {    
        horizontal = context.ReadValue<Vector2>().x;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Terrain") isGrounded = true;
        anim.SetBool("Saltando", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Terrain") isGrounded = false;
        //anim.SetBool("Saltando", true);
    }
}
