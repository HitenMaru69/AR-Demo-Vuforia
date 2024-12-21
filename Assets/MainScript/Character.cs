using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Character : MonoBehaviour
{
    [Header("Rotate Chracter")]
    public float rotationSpeed = 1f; // Speed of rotation
    public float moveSpeed = 0.1f;    // Speed for moving the object

    [Space(10)]
    [Header("Scale Character")]
    public float pinchSpeed = 0.1f; // Speed of scaling
    private float initialDistance; // Initial distance between two touches
    private float initialScale;    // Initial scale of the object
    private bool isTouchingCharacter = false; // To track if the character is being touched


    private void Update()
    {
        CharacterRotationAndMove();
        ZoomINZoomOutCharacter();
    }


    #region character Rotation


    void CharacterRotationAndMove()
    {
        if (Input.touchCount == 1)
        {
            //// Handle one-finger movement of the object
            //Touch touch = Input.GetTouch(0);

            //// Perform a raycast to check if the touch is on the object
            //Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.transform == transform)
            //    {
            //        if (touch.phase == TouchPhase.Moved)
            //        {

            //            // Else try this code

            //            // Get movement direction based on touch delta
            //            Vector3 moveDirection = new Vector3(
            //                touch.deltaPosition.x,
            //                touch.deltaPosition.y, // Y-axis movement
            //                touch.deltaPosition.y // Map Y-axis to Z-axis for perspective
            //            );

            //            // Adjust movement speed and apply translation
            //            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            //        }

            //        //  if Above Code not Work than remove above code and uncommint below code

            //        //if (touch.phase == TouchPhase.Moved)
            //        //{
            //        //    // Move the object in the direction of the finger's movement
            //        //    Vector3 moveDirection = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);
            //        //    transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            //        //}
            //    }
            //}
        }
        else if (Input.touchCount == 2)
        {


            // Handle two-finger rotation of the character
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Check if both touches are on the character
            if (IsTouchingCharacter(touch1.position) && IsTouchingCharacter(touch2.position))
            {
                // Calculate the average delta position of both fingers
                Vector2 averageDelta = (touch1.deltaPosition + touch2.deltaPosition) / 2f;

                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    // Rotate the character around the Y-axis
                    float rotationAmount = averageDelta.x * rotationSpeed * Time.deltaTime;
                    transform.Rotate(0f, -rotationAmount, 0f);
                }
            }
        }
    }


    #endregion

    #region ZoominZoomOut Character

    void ZoomINZoomOutCharacter()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Perform raycast on the first touch to check if it hits the character
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                isTouchingCharacter = IsTouchingCharacter(touch1.position) || IsTouchingCharacter(touch2.position);

                if (isTouchingCharacter)
                {
                    // Store the initial distance and scale
                    initialDistance = Vector2.Distance(touch1.position, touch2.position);
                    initialScale = transform.localScale.x; // Use x-axis for uniform scaling
                }
            }

            // If both touches are moving and the character is touched
            if (isTouchingCharacter)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleChange = (currentDistance - initialDistance) * pinchSpeed;

                // Apply the scale change
                float newScaleValue = Mathf.Max(0.5f, initialScale + scaleChange); // Clamp to a minimum of 0.5
                Vector3 newScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);

                transform.localScale = newScale;
            }
        }
        else if (Input.touchCount == 0) // Reset when no touches
        {
            isTouchingCharacter = false;
        }
    }


    #endregion

    // Helper function to check if a touch is on the character
    private bool IsTouchingCharacter(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit this character
            return hit.transform == transform;
        }
        return false;
    }


}
