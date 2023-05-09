using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;
    public int defenseLevel = 5;
    public int maxDefense;

    Animator animator;

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
