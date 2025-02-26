using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        rb.isKinematic = true;
    }

    public void SetToRigidbodyNormal()
    {
        rb.isKinematic = false;
    } 

}
