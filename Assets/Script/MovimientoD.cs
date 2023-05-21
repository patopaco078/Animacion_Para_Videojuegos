using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoD : MonoBehaviour
{
    private bool isInAir = false;
    private bool isAttacking = false;
    private bool isRunning;
    private bool isIdle;
    private bool isBreakAnimationPlaying;
    private bool isActionInProgress;
    private bool canMove = true;
    public bool isSlowWalking = false;


    public GameObject lifePickupPrefab;
    private GameObject currentLifePickup;
    private bool canPickupLife = true;


    public float slowMoveSpeed = 2f;

    public int lives = 2;
    private bool canTakeDamage = true;
    public float damageCooldown = 3f;


    public Rigidbody rb;
    public Animator animator;
    private Vector2 movementInput;
    private bool isJumping;
    private bool isGrounded;
    private bool canJump = true;

    public float moveSpeedI = 5f;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public float idleTimeThreshold = 3f;
    private float idleTimer = 0f;

    private void Update()
    {
        Move();
        Jump();
        Attack();
        CheckIdle();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Move()
    {

        float currentMoveSpeed = moveSpeed;
        if (isSlowWalking)
        {
            currentMoveSpeed = slowMoveSpeed;
            moveSpeed = slowMoveSpeed;
            animator.SetBool("IsSlowWalking", true);
        }
        else
        {
            moveSpeed = moveSpeedI;
            animator.SetBool("IsSlowWalking", false);
        }

        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        if (!isAttacking)
        {
            if (isGrounded && !isInAir)
            {
                if (movement.magnitude > 0.1f)
                {
                    animator.SetBool("IsMoving", true);
                }
                else
                {
                    animator.SetBool("IsMoving", false);
                }
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }


        if (isBreakAnimationPlaying && !isActionInProgress)
        {
            animator.ResetTrigger("Break");
            isBreakAnimationPlaying = false;
            isIdle = false;
        }
        if (!canMove)
        {
            // Detener el movimiento
            rb.velocity = Vector3.zero;
        }
    }

    public void OnShift(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isSlowWalking = true;
        }
        else if (context.canceled)
        {
            isSlowWalking = false;
        }
    }

    private void Jump()
    {
        if (isGrounded && isJumping && canJump && !isAttacking)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
            isJumping = false;
            canJump = false;
            isActionInProgress = true; // Establecer que se está realizando una acción
        }
    }

    private void Attack()
    {
        if (isGrounded && !isJumping)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                // Perform attack logic
                animator.SetTrigger("Attack");
                isActionInProgress = true; // Establecer que se está realizando una acción
                if (isBreakAnimationPlaying)
                {
                    animator.ResetTrigger("Break");
                    isBreakAnimationPlaying = false;
                    isIdle = false;
                }
            }
            else if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                // Perform different attack logic
                animator.SetTrigger("Attack2");
                isActionInProgress = true; // Establecer que se está realizando una acción
                if (isBreakAnimationPlaying)
                {
                    animator.ResetTrigger("Break");
                    isBreakAnimationPlaying = false;
                    isIdle = false;
                }
            }
            else if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                // Perform another attack logic
                animator.SetTrigger("Attack3");
                isActionInProgress = true; // Establecer que se está realizando una acción
                if (isBreakAnimationPlaying)
                {
                    animator.ResetTrigger("Break");
                    isBreakAnimationPlaying = false;
                    isIdle = false;
                }
            }
        }
    }

    private void Rotate()
    {
        if (movementInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (movementInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            canJump = true;
            isInAir = false;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (canTakeDamage)
            {
                TakeDamage();
                canTakeDamage = false;
                Invoke("ResetDamageCooldown", damageCooldown);
            }
        }
        else if (collision.gameObject.CompareTag("LifePickup"))
        {
            if (canPickupLife /*&& lives < 2*/)
            {
                PickupLife();
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }
    private void TakeDamage()
    {
        lives--;
        animator.SetTrigger("TakeDamage");
        if (lives <= 0)
        {
            Die();
        }
    }

    private void ResetDamageCooldown()
    {
        canTakeDamage = true;
    }

    private void Die()
    {
        // Perform death logic
        animator.SetTrigger("Die");
        canMove = false;
        // ... Additional code for death behavior ...
    }
    public void OnAttackAnimationEnd()
    {
        isAttacking = false;
        isActionInProgress = false; // Restablecer la acción en progreso
    }

    private void ApplyAdditionalGravity()
    {
        if (!isGrounded && rb.velocity.y < 0f)
        {
            rb.AddForce(Vector3.down * 10000, ForceMode.Acceleration);
        }
    }

    private void CheckIdle()
    {
        if (movementInput.magnitude > 0.1f || isJumping || isActionInProgress)
        {
            isIdle = false;
            idleTimer = 0f;
        }
        else
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTimeThreshold && !isIdle && !isBreakAnimationPlaying)
            {
                animator.SetTrigger("Break");
                isIdle = true;
                isBreakAnimationPlaying = true;
                isActionInProgress = true; // Establecer que se está realizando una acción
            }
        }
    }

    public void OnBreakAnimationEnd()
    {
        isBreakAnimationPlaying = false;
        isIdle = false;
        isActionInProgress = false; // Restablecer la acción en progreso
    }
    private void PickupLife()
    {
        lives++;
      /*  if (lives < 2)
        {
            lives = 2;
        }*/
        // Reproducir animación de recoger vida si es necesario
    }
}
