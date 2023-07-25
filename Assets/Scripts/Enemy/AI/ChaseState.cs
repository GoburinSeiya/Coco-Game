using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public CombatStanceState combatStanceState;

     public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimationManager enemyAnimationManager)
    {
        if(enemyManager.isPerformingAction)
            return this;

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - transform.position;
        enemyManager.distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        if(enemyManager.distanceFromTarget > enemyManager.maxAttackRange)
        {
            enemyAnimationManager.animator.SetFloat("Vertical", 1, enemyManager.chaseSpeed, Time.deltaTime);
        }

        HandleRotateToTarget(enemyManager );
        enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity; 

        if(enemyManager.distanceFromTarget <= enemyManager.maxAttackRange)
        {
            return combatStanceState;
        }
        else
        {
            return this;
        }
    }   

    private void HandleRotateToTarget(EnemyManager enemyManager)
    {
        if(enemyManager.isPerformingAction)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if(direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
        else //rotar con pathfinding navmesh
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(enemyManager.navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyManager.enemyRB.velocity;

            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            enemyManager.enemyRB.velocity = targetVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(transform.rotation, enemyManager.navMeshAgent.transform.rotation, 
            enemyManager.rotationSpeed / Time.deltaTime);
        }

        enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity;
    }
}
