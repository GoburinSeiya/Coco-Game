using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : Interactable
{
    public WeaponItem weapon;

    public override void Interact(playerManager PlayerManager)
    {
        base.Interact(PlayerManager); 

        //Recoger el arma y agregarla al inventario
        PickUpItem(PlayerManager);
    }

    private void PickUpItem(playerManager PlayerManager)
    {
        PlayerInventory playerInventory;
        playerMovement PlayerMovement;
        AnimationManager animationManager;

        playerInventory = PlayerManager.GetComponent<PlayerInventory>();
        PlayerMovement = PlayerManager.GetComponent<playerMovement>();
        animationManager = PlayerManager.GetComponentInChildren<AnimationManager>();
        
        //PlayerMovement.rb.velocity = Vector3.zero; 
        //animationManager.PlayTargetAniamtion("Pick up Item", true); animacion de looteo si es que hay
        playerInventory.weaponInventory.Add(weapon);
        Destroy(gameObject);
    }
}
