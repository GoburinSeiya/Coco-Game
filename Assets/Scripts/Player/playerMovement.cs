using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    playerManager playermanager;
    inputManager inManager;
    AnimationManager animatorManager;
    Animator animator;

    //Gravedad
    public float gravity = 9.8f;
    Vector3 playerVelocity;


    //Moverse
    public Vector3 moveDirection;
    Transform cameraObject;
    public float moveSpeed = 7;
    public float rotationSpeed = 16;

    //Caeerse
    public float fallvelocity;

    //Salto
    public float jumpForce;

    //comprobadores
    public bool isGrounded;
    public bool isJumping;  

    public CharacterController characterController;

    private void Awake()
    {
        inManager = GetComponent<inputManager>();
        characterController = GetComponent<CharacterController>();
        cameraObject = Camera.main.transform;
        //isGrounded = true;
        playermanager = GetComponent<playerManager>();
        animatorManager = GetComponent<AnimationManager>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (characterController.isGrounded)
        {
            //animatorManager.PlayTargetAniamtion("Landing", false);
        }
    }

    public void allPublicMovement()
    {
        HandleMovement();
        HandleRotation();
        SetGravity();
        characterController.Move(moveDirection * Time.deltaTime);
        if (playermanager.isInteracting)
        {
            return;
        }
    }

    private void HandleMovement()
    {

        moveDirection = cameraObject.forward * inManager.verticalInput;
        moveDirection += cameraObject.right * inManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * moveSpeed;

    }

    private void HandleRotation()
    {
   
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    public void HandleJumping()
    {
        if (characterController.isGrounded && !playermanager.isInteracting)
        {
            isGrounded = false;
            isJumping = true;
            fallvelocity = jumpForce;
            moveDirection.y = fallvelocity;
            characterController.Move(moveDirection * Time.deltaTime);
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAniamtion("Jump", true);

        }

    }

    public virtual void HandleGroundCheck()
    {
     
    }

    public void SetGravity()
    {
        if (characterController.isGrounded)
        {
            isGrounded = true;
            isJumping = false;
            fallvelocity = -gravity * Time.deltaTime;
            moveDirection.y = fallvelocity;
            if (isGrounded)
            {
               // animatorManager.PlayTargetAniamtion("Landing", false);
            }
            else
            {
                animator.SetBool("isGrounded", false);
            }
        }
        else
        {
            animator.SetBool("Falling", false);

            fallvelocity -= gravity * Time.deltaTime;
            isGrounded = false;
            moveDirection.y = fallvelocity;
        }

    }

 
    private void OnDrawGizmosSelected()
    {
    }
}
