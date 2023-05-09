using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;
    WeaponHolderSlot backSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;
    DamageCollider backSlotDamageCollider;

    private void Awake() 
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if(weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if(weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
            else if(weaponSlot.isBackItemSlot)
            {
                backSlot = weaponSlot;
            }
        }
    }   

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft, bool isBack)
    {
        if(isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            LoadLeftWeaponDamageCollider();
        }
        if(isBack)
        {
            backSlot.LoadWeaponModel(weaponItem);
            LoadBackSlotDamageCollider();
        }
        if(!isLeft && !isBack)
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollider();
        }
    }

    public void LoadLeftWeaponDamageCollider()
    {
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightWeaponDamageCollider()
    {
        rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadBackSlotDamageCollider()
    {
        backSlotDamageCollider = backSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    #region Animation Event Collider Handler
    public void OpenRightDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
    }

    public void OpenLeftDamageCollider()
    {
        leftHandDamageCollider.EnableDamageCollider();
    }

    public void OpenBackDamageCollider()
    {
        backSlotDamageCollider.EnableDamageCollider();
    }

    public void CloseRightDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void CloseLeftDamageCollider()
    {
        leftHandDamageCollider.DisableDamageCollider();
    }

    public void CloseBackDamageCollider()
    {
        backSlotDamageCollider.DisableDamageCollider();
    }
    #endregion
}
