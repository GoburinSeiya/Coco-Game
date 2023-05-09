using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    playerManager playermanager;
    inputManager inManager;
    public Rigidbody rb;
    AnimationManager animatorManager;
    Animator animator;

    //Moverse
    public Vector3 moveDirection;
    Transform cameraObject;
    public float moveSpeed = 7;
    public float rotationSpeed = 16;

    //Caeerse
    public float airTime;
    public float leapVelocity;
    public float fallSpeed;
    public float rayCastOffSet = 0.5f;
    public LayerMask groundLayer;
    //Salto
    public float maxHeight = 3;
    public float gravityForce = -15f;
    //comprobadores
    public bool isGrounded;
    public bool isJumping;

    private void Awake()
    {
        inManager = GetComponent<inputManager>();
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        //isGrounded = true;
        playermanager = GetComponent<playerManager>();
        animatorManager = GetComponent<AnimationManager>();
        animator = GetComponent<Animator>();
    }

    public void allPublicMovement()
    {
        HandleFallAndLanding();

        if (playermanager.isInteracting)
        {
            return;
        }
        HandleMovement();
        HandleRotation();

    }
    private void HandleMovement()
    {
        if (isJumping)
        {
            return;
        }

        moveDirection = cameraObject.forward * inManager.verticalInput;
        moveDirection += cameraObject.right * inManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * moveSpeed;

        Vector3 moveForce = moveDirection;
        rb.velocity = moveForce;
    }

    private void HandleRotation()
    {

        if (isJumping)
        {
            return;
        }
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

    private void HandleFallAndLanding()
    {
        RaycastHit hit;
        Vector3 rcastOrigin = transform.position;
        Vector3 targetPosition;
        rcastOrigin.y += rayCastOffSet;
        targetPosition = transform.position;

        if (!isGrounded && !isJumping)
        {
            if (!playermanager.isInteracting)
            {
                animatorManager.PlayTargetAniamtion("Falling", true);
            }
            airTime += Time.deltaTime;
            rb.AddForce(transform.forward * leapVelocity);
            rb.AddForce(-Vector3.up * fallSpeed * airTime);
        }

        if (Physics.SphereCast(rcastOrigin, 0.2f, Vector3.down, out hit, rayCastOffSet, groundLayer))
        {
            if (!isGrounded && !playermanager.isInteracting)
            {
                animatorManager.PlayTargetAniamtion("Landing", true);
            }
            
            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
            airTime = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
        }

        if(isGrounded && !isJumping)
        {
            if(playermanager.isInteracting || inManager.moveAmount > 0)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime /0.01f);
            }
            else
            {
                transform.position = targetPosition;
            }
        }

    }
    public void HandleJumping()
    {
        if (isGrounded)
        {
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAniamtion("Jump", false);
            Debug.Log("this works");
            float jumpSpeed = Mathf.Sqrt(-2 * gravityForce * maxHeight);
            Vector3 playerVelocity = moveDirection;
            playerVelocity.y = jumpSpeed;
            rb.velocity = playerVelocity;
        }
    }
}
