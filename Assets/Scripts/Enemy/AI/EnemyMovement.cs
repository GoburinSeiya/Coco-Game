using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAnimationManager enemyAnimationManager;
    

    private void Awake() 
    {
        enemyManager = GetComponent<EnemyManager>();
        enemyAnimationManager = GetComponentInChildren<EnemyAnimationManager>();
    }


}
