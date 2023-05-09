using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;

    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;
    public WeaponItem backWeapon;

    public List<WeaponItem> weaponInventory;

    private void Awake() 
    {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }
}
