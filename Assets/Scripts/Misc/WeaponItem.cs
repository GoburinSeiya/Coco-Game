using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Weapon Item")]
public class WeaponItem : Item
{
    public GameObject modelPrefab;
    public bool isUnarmed;

    [Header("Axe Animations")]
    public string OH_Axe_Light_Attack;
    public string OH_Axe_Heavy_Attack;
}
