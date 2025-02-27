using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField]private Rigidbody rb;
    [SerializeField] PlayerAnimation playerAnimation;
    private float xdir;
    private float zdir;
    private Vector3 movedirection;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        xdir = Input.GetAxisRaw("Horizontal");
        zdir  = Input.GetAxisRaw("Vertical");

        //if (xdir > 0 || zdir > 0)
        //{
        //    playerAnimation.PlayRunAnimation();
        //}
        //else
        //{
        //    playerAnimation.PlayIdleAnimation();
        //}

        if (Input.GetKeyDown(KeyCode.I))
        {
            playerAnimation.PlayIdleAnimation();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerAnimation.PlayRunAnimation();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.PLayAttackAnimation();
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.MovePosition(new Vector3(rb.position.x +  xdir * playerSpeed, rb.transform.position.y, rb.position.z +zdir * playerSpeed)); 
    }



}
