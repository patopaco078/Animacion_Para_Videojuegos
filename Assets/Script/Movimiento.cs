using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public Animator animator;

    int isWalkingHash;
    int isRunningHash;

    Controles input;

    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;

    private void Awake()
    {
        input = new Controles();

        input.Personaje.Movimiento.performed += ctx =>
        {
            currentMovement=ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
        input.Personaje.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();

    }

    void Start()
    {

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        handlemovement();
        handlerotation();
    }

    void handlerotation() 
    {
        Vector3 currentPosition = transform.position;

        Vector3 newposition = new Vector3(currentMovement.x, 0, currentMovement.y);

        Vector3 positiontolookat = currentPosition + newposition;

        transform.LookAt(positiontolookat);

    }
    void handlemovement() 
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        if (movementPressed && !isWalking)
            animator.SetBool(isWalkingHash, true);

        if (movementPressed && isWalking)
            animator.SetBool(isWalkingHash, false);

        if ((movementPressed && runPressed) && !isRunning)
            animator.SetBool(isRunningHash, true);

        if ((!movementPressed || !runPressed) && isRunning)
            animator.SetBool(isRunningHash, false);

    }

    private void OnEnable()
    {
        input.Personaje.Enable();
    }

    private void OnDisable()
    {
        input.Personaje.Disable();
    }

}
