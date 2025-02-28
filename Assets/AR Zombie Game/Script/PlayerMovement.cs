using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField]private  Rigidbody rb;
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] FixedJoystick joystick;
    private float xdir;
    private float zdir;

    private void Update()
    {
        xdir = Input.GetAxisRaw("Horizontal");
        zdir  = Input.GetAxisRaw("Vertical");
        
        if(Mathf.Abs(xdir) > 0 || Mathf.Abs(zdir) > 0 || 
            Mathf.Abs(joystick.Horizontal) > 0 || Mathf.Abs(joystick.Vertical) > 0)
        {
            if (!playerAnimation.GetIsAttack()) 
            {
                playerAnimation.PlayRunAnimation();
            }
        }
        else
        {
            if (!playerAnimation.GetIsAttack()) 
            {
                playerAnimation.PlayIdleAnimation();
            }
        }



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        // For KeyBoard Input

        Vector3 moveDirection = new Vector3(xdir, 0, zdir).normalized;

        rb.MovePosition(rb.position + moveDirection * playerSpeed * Time.fixedDeltaTime);

        if (moveDirection != Vector3.zero)
        {

            transform.forward = moveDirection;
        }

        // For Joystick Input

        Vector3 joystickMoveDirection = new Vector3(joystick.Horizontal, 0 ,joystick.Vertical);

        rb.MovePosition(rb.position + joystickMoveDirection * playerSpeed * Time.fixedDeltaTime);

        if (joystickMoveDirection != Vector3.zero)
        {

            transform.forward = joystickMoveDirection;
        }


    }


}
