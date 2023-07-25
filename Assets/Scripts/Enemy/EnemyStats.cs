using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public Animator animator;

    private void Awake() 
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start() 
    {
        maxHealth = SetMaxHealthFromLevel();
        maxDefense = SetMaxDefenseFromLevel();
        currentHealth = maxHealth;
    }

    private int SetMaxHealthFromLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    private int SetMaxDefenseFromLevel()
    {
        maxDefense = defenseLevel * 5;
        return maxDefense;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        animator.Play("Damage");

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            animator.Play("Death");
            //HandleEnemyDeath():
        }
    }
}
