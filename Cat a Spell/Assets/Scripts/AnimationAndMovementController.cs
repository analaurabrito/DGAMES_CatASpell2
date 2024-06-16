using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;
    public float Speed = 10.0f;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    float rotationFactorPerFrame = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();


        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;
    }

    void onMovementInput (InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if(isMovementPressed){
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
       
    }
    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");

        if(isMovementPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else if(!isMovementPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
    }

    void handleGravity()
    {
        if(characterController.isGrounded){
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
        }else{
            float gravity = -9.8f;
            currentMovement.y += gravity;
        }
    }
    // Update is called once per frame
    void Update()
    {
        handleGravity();
        handleRotation();
        handleAnimation();
        characterController.Move(currentMovement * Time.deltaTime * Speed);
    }

    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}