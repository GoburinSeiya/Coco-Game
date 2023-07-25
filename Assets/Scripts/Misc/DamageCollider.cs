using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;
    PlayerStats playerStats;
    int currentWeaponDamage = 50;
    int totalDamage;

    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        playerStats = GetComponent<PlayerStats>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player") //Para dañar al jugador
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            if(playerStats != null)
            {
                playerStats.TakeDamage(currentWeaponDamage);
            }
        }

        if(collision.tag == "Enemy") //Para dañar al enemigo
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();

            if(enemyStats != null)
            {
                currentWeaponDamage = playerStats.maxDamage;
                totalDamage = enemyStats.maxDefense - currentWeaponDamage;
                enemyStats.TakeDamage(totalDamage);
            }
        }

        if(collision.tag == "Hittable") //Util para puzzles u otros objetos
        {
            //ObjectManager objectManager = collision.GetComponent<objectManager>();

            //if(objectManager != null)
            //{
            //  currentWeaponDamage = playerStats.maxDamage;
            //  objectManager.TakeDamage(currentWeaponDamage);
            //}
        }
    }
}
