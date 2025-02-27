using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] MeshRenderer meshRenderer;


    private void Update()
    {
        meshRenderer.enabled = false;
    }

    public void AttackButton()
    {
        playerAnimation.PlayAttackAnimation();
 
    }
}
