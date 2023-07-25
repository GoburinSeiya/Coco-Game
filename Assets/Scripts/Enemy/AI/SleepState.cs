using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : State
{
    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimationManager enemyAnimationManager)
    {
        return this;
    }
}
