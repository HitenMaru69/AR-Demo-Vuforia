using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;




    public void PlayWalkAnimation()
    {
        enemyAnimator.SetBool("isRun", true);
        enemyAnimator.SetBool("isAttack", false);
    }

    public void PlayAttackAnimation()
    {
        enemyAnimator.SetBool("isRun", false);
        enemyAnimator.SetBool("isAttack", true);
    }
}
