using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;



    public void PlayIdleAnimation()
    {
        playerAnimator.SetBool("isIdle",true);
        playerAnimator.SetBool("isRun",false);
        playerAnimator.SetBool("isAttack",false);
    }

    public void PlayRunAnimation()
    {
        playerAnimator.SetBool("isIdle", false);
        playerAnimator.SetBool("isRun", true);
        playerAnimator.SetBool("isAttack", false);
    }

    public void PLayAttackAnimation()
    {
        playerAnimator.SetBool("isIdle", false);
        playerAnimator.SetBool("isRun", false);
        playerAnimator.SetBool("isAttack", true);
    }
}
