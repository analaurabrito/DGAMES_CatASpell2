using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charController;
    Animator animator;

    bool isMovementPressed;
    float rotationFactorPerFrame = 1.0f;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }


    void handleAnimation()
    {
        bool isWalking = animator.GetBool("isWalking");

        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && !isWalking)
        {
            animator.SetBool("isWalking", true);
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

    /*public float speed = 20;
    public float turnSpeed = 30;
    public float horizontalInput;
    public float forwardInput;
    public float xRange = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input de movimentação
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Para o gatinho andar pra frente
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Para o gatinho se movimentar (de forma rotacionada) para direita/esquerda
        transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * turnSpeed* Time.deltaTime);

       // Para manter o jogador nos limites do terreno
       if(transform.position.x < -xRange)
        {
            transform.position= new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }*/
}

