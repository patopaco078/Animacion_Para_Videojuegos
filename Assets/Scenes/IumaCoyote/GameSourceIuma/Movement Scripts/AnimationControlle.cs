using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Iumita
{
    [RequireComponent(typeof(Animator))]

    public class AnimationControlle : MonoBehaviour
    {
        Animator animator;
        bool isIdle;
        Rigidbody rb;
        bool isGrounded;
        //damage
        [SerializeField] int maxHealth = 100;
        [SerializeField] int currentHealth;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();

        }
        private void Start()
        {
            currentHealth = maxHealth;
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            animator.SetFloat("verticalSpeed", rb.velocity.y);

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                isGrounded = true;
                animator.SetBool("isGrounded", isGrounded);
            }
            if (collision.gameObject.CompareTag("Enemy")) // Assuming the damaging object has the "Enemy" tag
            {
                int damage = 5; // Adjust the damage value as needed
                TakeDamage(damage);
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
            if (value <= 0.1f && !isIdle)
            {
                isIdle = true;
                StartCoroutine(SetBreak());
            }
            if (isIdle && value > 0.1f)
            {
                StopAllCoroutines();
                isIdle = false;
                animator.SetBool("break", false);
            }


        }

        IEnumerator SetBreak()
        {
            yield return new WaitForSeconds(5f);
            animator.SetTrigger("break");
            isIdle = false;
        }
        public void SetAttackTrigger1()
        {
            animator.SetTrigger("attack1");

        }
        public void SetAttackTrigger2()
        {
            animator.SetTrigger("attack2");

        }
        public void SetAttackTrigger3()
        {
            animator.SetTrigger("attack3");

        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                //currentHealth = 0;
                animator.SetTrigger("Death");
                // Trigger death animation or any other actions for death
            }
            else
            {
                // Trigger damage animation or any other actions for taking damage
                animator.SetTrigger("Damage"); // Assuming you have a trigger parameter called "Damage" in your animator
            }
            Debug.Log("Current Health : " + currentHealth);
        }

    }

}
