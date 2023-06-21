using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    PlayerControls playerControls;
    playerMovement plyrMovement;
    AnimationManager animatorManager;
    PlayerActions playerActions;
    PlayerInventory playerInventory;

    [Header("Movimiento")]
    public Vector2 movementInput;
    public Vector2 cameraInput; 

    [Header("Camara")]
    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    [Header("Input Acciones")]
    public bool jump_input;
    public bool biteInput;
    public bool axeInput;
    public bool boomerangInput;
    public bool torchInput;
    public bool dashInput;

    [Header("Interacciones")]
    public bool A_Input;
    
    //[Header("Misc declarations")]
    //public float startHeld = 0.0f;
    //public float heldTime = 0.0f;

    private void Awake()
    {
        plyrMovement = GetComponent<playerMovement>();
        animatorManager = GetComponent<AnimationManager>();
        playerActions = GetComponent<PlayerActions>();
        playerInventory = GetComponent<PlayerInventory>();
    }
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Playermovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.Playermovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Jump.performed += i => jump_input = true; //Sintaxis para press
            playerControls.PlayerActions.Bite.performed += i => biteInput = true;
            playerControls.PlayerActions.Axe.performed += i => axeInput = true;
            playerControls.PlayerActions.Torch.performed += i => torchInput = true;
            playerControls.PlayerActions.Boomerang.performed += i => boomerangInput = true; //Sintaxis para mantener el boton
            playerControls.PlayerActions.Boomerang.canceled += i => boomerangInput = false;
            playerControls.PlayerActions.Dash.performed += i => dashInput = true; 
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void allPublicInputs()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleDash();
        HandleAttackInput();
        //HandleBoomerangInput();
        HandleInteractionInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleJumpInput()
    {
        if (jump_input)
        {
            jump_input = false;
            plyrMovement.HandleJumping();
        }

    }

    private void HandleDash()
    {
        if (dashInput)
        {
            dashInput = false;
            Debug.Log("Dash input");
            plyrMovement.HandleDash();
        }
    }

    private void HandleAttackInput()
    {
        if(biteInput)
        {
            Debug.Log("Bite");
            biteInput = false;
            playerActions.HandleBiteAttack();
        }

        if(axeInput)
        {
            Debug.Log("Axe");
            axeInput = false;
            if (playerInventory.rightWeapon == null)
            {
                return;
            }
            else
            {
                playerActions.HandleAxeAttack(playerInventory.rightWeapon);
            }
        }

        if(torchInput)
        {
            Debug.Log("Torch");
            torchInput = false;
            if (playerInventory.leftWeapon == null)
            {
                return;
            }
            else
            {
                playerActions.HandleTorchAttack(playerInventory.leftWeapon);
            }
            
        }
    }

    /*
    private void HandleBoomerangInput()
    {
        if(boomerangInput)
        {
            playerActions.StartTimeCounter(startHeld);
        }
        else
        {
            playerActions.HandleBoomerangAttack(playerInventory.backWeapon, heldTime, startHeld);
        }
    }
    */
    private void HandleInteractionInput()
    {
        playerControls.Interactions.Interactbutton.performed += i => A_Input = true;
    }

}
