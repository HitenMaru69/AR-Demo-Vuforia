using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] float forceSpeed;

    private void Start()
    {
        rb.isKinematic = true;
        boxCollider.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            rb.velocity = -transform.forward * forceSpeed;
        }
    }


    public void SetToRigidbodyNormal()
    {
        rb.isKinematic = false;
    } 

    public void EnableBoxCollider()
    {
        boxCollider.enabled = true;
    }
    public void DisableBoxCollider()
    {
        boxCollider.enabled = false;
    }


    // Player and Enemy Health
    // Spwan Enemy 
    // UI
}
