using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    
    public void AttackButton()
    {
        playerAnimation.PlayAttackAnimation();
 
    }
}
