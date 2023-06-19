using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    AnimationManager animationManager;

    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;
    public int damageLevel;
    public int maxDamage;
    public int currentWeaponDamage;

    public HealthBar healthBar;

    private void Awake() 
    {
        animationManager = GetComponentInChildren<AnimationManager>();
    }

    void Start() 
    {
        maxHealth = SetMaxHealtFromHealthLevel();
        maxDamage = SetMaxDamageFromLevel();
        currentWeaponDamage = maxDamage;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private int SetMaxHealtFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    private int SetMaxDamageFromLevel()
    {
        maxDamage = damageLevel * 10;
        return maxDamage;
    }

    public void TakeDamage(int TakeDamage)
    {
        currentHealth = currentHealth - TakeDamage;
        healthBar.SetCurrentHealth(currentHealth);
        //animationManager.PlayTargetAniamtion("TakeDamage", true);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            //animationManager.PlayTargetAnimation("Death", true);
            //HandleGameOver();
        }
    }

    public void Heal(int heal)
    {
        if ((currentHealth + heal)>=maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + heal;
        }
        healthBar.SetCurrentHealth(currentHealth);
        //animationManager.PlayTargetAniamtion("Heal", true);
        Debug.Log("Healed for" + heal);
    }
}
