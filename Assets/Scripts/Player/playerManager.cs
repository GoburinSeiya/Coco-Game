using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    inputManager inManager;
    playerMovement plyrMovement;
    CameraManager cameraManager;
    public Animator animator;
    WeaponSlotManager weaponSlotManager;
    WeaponPickUp weaponPickUp;
    PlayerInventory playerInventory;


    public bool isInteracting;
    public float interactRange = 0.1f;

    private void Awake()
    {
        inManager = GetComponent<inputManager>();
        plyrMovement = GetComponent<playerMovement>();
        cameraManager = FindObjectOfType<CameraManager>(); //Usas FindObjectOfType cuando solo quieres uno de estos objetos en la escena
        animator = GetComponent<Animator>(); 
        weaponSlotManager = GetComponent<WeaponSlotManager>();
        weaponPickUp = GetComponent<WeaponPickUp>();
        playerInventory = GetComponent<PlayerInventory>();
    }
    private void FixedUpdate()
    {
        inManager.allPublicInputs();

        CheckForInteractableObject();

        plyrMovement.allPublicMovement();

    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();

        isInteracting = animator.GetBool("isInteracting");
        //plyrMovement.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", plyrMovement.isGrounded);

        inManager.A_Input = false;
    }

    public void CheckForInteractableObject()
    {
        RaycastHit hit;

        if(Physics.SphereCast(transform.position, interactRange, transform.forward, out hit, 1f /*, cameraManager.ignoreLayers */))
        {
            if(hit.collider.tag == "Interactable")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if(interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText; 
                    //Ajustamos el mensaje de texto en la UI del objeto interactuable
                    //Pop up true aquí

                    if(inManager.A_Input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                    }
                }
             }  
            if(hit.collider.tag == "Axe")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if (interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText; 
                    //Ajustamos el mensaje de texto en la UI del objeto interactuable
                    //Pop up true aquí

                    if(inManager.A_Input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                        WeaponItem weaponPick = hit.collider.GetComponent<WeaponPickUp>().weapon; //Obtener un objeto asignado a otro script al momento de la colisión
                        playerInventory.rightWeapon = weaponPick;
                        weaponSlotManager.LoadWeaponOnSlot(weaponPick, false, false);
                        Debug.Log(weaponPick);
                    }
                }
            }
            if(hit.collider.tag == "Torch")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if(interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText; 
                    //Ajustamos el mensaje de texto en la UI del objeto interactuable
                    //Pop up true aquí

                    if(inManager.A_Input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                        WeaponItem weaponPick = hit.collider.GetComponent<WeaponPickUp>().weapon; //Obtener un objeto asignado a otro script al momento de la colisión
                        playerInventory.leftWeapon = weaponPick;
                        weaponSlotManager.LoadWeaponOnSlot(weaponPick, true, false);
                        Debug.Log(weaponPick);
                    }
                }
            }

            if(hit.collider.tag == "Boomerang")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if(interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText; 
                    //Ajustamos el mensaje de texto en la UI del objeto interactuable
                    //Pop up true aquí

                    if(inManager.A_Input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                        WeaponItem weaponPick = hit.collider.GetComponent<WeaponPickUp>().weapon;
                        playerInventory.backWeapon = weaponPick;
                        weaponSlotManager.LoadWeaponOnSlot(weaponPick, false, true);
                        Debug.Log(weaponPick);
                    }
                }
            }
        }
    }
}
