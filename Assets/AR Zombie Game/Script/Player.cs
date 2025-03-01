using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] float forceSpeed;
    [SerializeField] HealthBar healthBar;

    private void Start()
    {
        rb.isKinematic = true;
        boxCollider.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            healthBar.ReduceHealth();

            if(healthBar.GetCurrentHealth() > 0)
            {
                rb.velocity = -transform.forward * forceSpeed;
            }
            else
            {
                PlayerDie();
            }
            
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

    private void PlayerDie()
    {
        Destroy(this.gameObject);
    }

    // Spwan Enemy 
    // UI
}
