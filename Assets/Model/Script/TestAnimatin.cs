using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimatin : MonoBehaviour
{
  
    public Animator animator;


    private void Update()
    {
        ClickBu();
    }

    public void ClickBu()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("idle", false);
            animator.SetBool("Run", true);

        }
    }
}
