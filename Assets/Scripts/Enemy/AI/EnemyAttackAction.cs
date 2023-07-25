using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Enemy Actions/Attack Actions")]
public class EnemyAttackAction : EnemyActions
{
   public int attackScore = 3;
   public float recoveryTime = 2;

   public float maximumAttackAngle = 35;
   public float minimumAttackAngle = -35; 

   public float minimumDistanceToAttack;
   public float maximumDistanceToAttack;
}
