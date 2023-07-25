using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : GlobalAnimationManager
{
    EnemyManager enemyManager;
    public float speedFactor;

    private void Awake() 
    {
        animator = GetComponent<Animator>();  
        enemyManager = GetComponent<EnemyManager>();  
    }

    private void OnAnimatorMove()
    {
        float delta = Time.deltaTime;
        enemyManager.enemyRB.drag = 0;
        Vector3 deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        enemyManager.enemyRB.velocity = velocity*speedFactor;    
    }
}
