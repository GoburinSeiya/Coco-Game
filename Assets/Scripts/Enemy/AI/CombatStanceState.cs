using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStanceState : State
{   
    public AttackState attackState;
    public ChaseState chaseState;

     public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimationManager enemyAnimationManager)
    {
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        
        if(enemyManager.currentRecoveryTime <= 0 && enemyManager.distanceFromTarget <= enemyManager.maxAttackRange)
        {
           return attackState; 
        }
        else if (enemyManager.distanceFromTarget > enemyManager.maxAttackRange)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }   
}
