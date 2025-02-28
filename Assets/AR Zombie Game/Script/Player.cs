using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider boxCollider;

    private void Start()
    {
        rb.isKinematic = true;
        boxCollider.enabled = false;
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

}
