using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charController;
    Animator animator;
    // private UnityEngine.AI.NavMeshAgent navMeshAgent;

    bool isMovementPressed;
    float rotationFactorPerFrame = 1.0f;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        // navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !isWalking)
        {
            animator.SetBool("isWalking", true);
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && !isRunning)
            {

                animator.SetBool("isRunning", true);
                
            }
            else if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && isRunning)
            {

                animator.SetBool("isRunning", false);
                
            }
        }
        else if ((Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0) && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;


        positionToLookAt.x = Input.GetAxis("Vertical");
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = Input.GetAxis("Horizontal");

        Quaternion currentRotation = transform.rotation;

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    // Update is called once per frame
    void Update()
    {
        handleAnimation();
        handleRotation();
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        // navMeshAgent.destination = move;
        if (charController.isGrounded)
        {
            float groundedGravity = -.05f;
            move.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            move.y += gravity;
        }
        charController.Move(move * Time.deltaTime * Speed);
    }
}
