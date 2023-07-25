using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAnimationManager : MonoBehaviour
{
    public Animator animator;
   public void PlayTargetAniamtion(string targetAnimation, bool isInteracting)
    {
        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFade(targetAnimation, 0.2f);
    }

    public void PlayEnemyAnimation(string targetAnimation)
    {
        animator.CrossFade(targetAnimation, 0.2f);
    }
}
