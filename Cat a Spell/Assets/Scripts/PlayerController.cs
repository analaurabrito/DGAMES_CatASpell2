using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charController;
    Animator animator;
    
    bool isMovementPressed;
    float rotationFactorPerFrame = 120f;
    public float moveSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
       charController = GetComponent<CharacterController>();
       animator = GetComponent<Animator>();

    }


    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");

        if((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)  && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        else if((Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0) && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
    }

    void handleRotation()
    {
        /* Vector3 positionToLookAt;
        

        positionToLookAt.x = Input.GetAxis("Vertical");
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = Input.GetAxis("Horizontal");

       Quaternion currentRotation = transform.rotation;

        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        } */
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up, rotationFactorPerFrame * Time.deltaTime, Space.Self);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationFactorPerFrame * Time.deltaTime, Space.Self);
        }

       
    }
    
    // Update is called once per frame
    void Update()
    {
        handleAnimation();
        handleRotation();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = transform.TransformDirection(move);
        if(charController.isGrounded){
            float groundedGravity = -.05f;
            move.y = groundedGravity;
        }else{
            float gravity = -9.8f;
            move.y += gravity;
        }
        charController.Move(move * Time.deltaTime * moveSpeed);
    }
}
