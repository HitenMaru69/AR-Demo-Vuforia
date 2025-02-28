using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] bool isAttack;
    [SerializeField] Player player;


    private void Start()
    {
         PlayIdleAnimation();
    }

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

    public void PlayAttackAnimation()
    {
        isAttack = true;
        playerAnimator.SetBool("isIdle", false);
        playerAnimator.SetBool("isRun", false);
        playerAnimator.SetBool("isAttack", true);
        StartCoroutine(PlayIdleAnimationAfterAttack());
       

    }

    IEnumerator PlayIdleAnimationAfterAttack()
    {
        yield return new WaitForSeconds(0.5f);
        player.EnableBoxCollider();
        yield return new WaitForSeconds(1.5f);
        player.DisableBoxCollider();
        PlayIdleAnimation();
        isAttack = false;
    }

    public bool GetIsAttack()
    {
        return isAttack;
    }
}
