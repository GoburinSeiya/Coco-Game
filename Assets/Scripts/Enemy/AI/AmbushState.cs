using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushState : State
{
    public bool  isSleeping; 
    public float detectionRadius;
    public string sleepAnimation;
    public string wakeAnimation;
    public LayerMask detectionLayer;

    public CombatStanceState combatStanceState;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimationManager enemyAnimationManager)
    {
        if(isSleeping && enemyManager.isInteracting == false)
        {
            enemyAnimationManager.PlayTargetAniamtion(sleepAnimation, true);
        }

        #region Handle Target Detection
        Collider[] colliders = Physics.OverlapSphere(enemyManager.transform.position, detectionRadius, detectionLayer);

        for(int i = 0; i < colliders.Length; i++ )
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if(characterStats != null)
            {
                Vector3 targetsDirection = characterStats.transform.position - enemyManager.transform.position;
                enemyManager.viewableAngle = Vector3.Angle(targetsDirection, enemyManager.transform.forward);

                if(enemyManager.viewableAngle > enemyManager.minDetectionAngle
                && enemyManager.viewableAngle < enemyManager.maxDetectionAngle)
                {
                    enemyManager.currentTarget = characterStats;
                    isSleeping = false;
                    enemyAnimationManager.PlayTargetAniamtion(wakeAnimation, true);
                    enemyManager.isInteracting = false;
                }
            }
        }
        #endregion
        
        #region Handle State Change
        if(enemyManager.currentTarget != null)
        {
            return combatStanceState;
        }
        else
        {
            return this;
        }
        #endregion
    }
}
