using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int defenseLevel = 10;
    public int maxHealth;
    public int currentHealth;
    public int damageLevel;
    public int maxDamage;
    public int maxDefense;
    public int currentWeaponDamage;

    public HealthBar healthBar;
}
