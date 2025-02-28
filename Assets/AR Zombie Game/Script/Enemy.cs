using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float enemySpeed;
    [SerializeField] float distanceBetweenPlayerAndZombie;
    [SerializeField] EnemyAnimation enemyAnimation;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] float forceSpeed;


    private void Start()
    {
        boxCollider.enabled = false;
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Axe")
        {
            rb.velocity = -transform.forward * forceSpeed;
        }
    }


    public void SetRigidBodyDynamic()
    {
        rb.isKinematic = false;
    }

    private void FollowPlayer()
    {
        Player player = FindObjectOfType<Player>();

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > distanceBetweenPlayerAndZombie)
        {
            Vector3 direction =  player.gameObject.transform.position - transform.position ;

            rb.MovePosition(rb.position + direction * enemySpeed * Time.deltaTime);

            if (direction != Vector3.zero) { 
            
                transform.forward = direction;
            }

            enemyAnimation.PlayWalkAnimation();

            boxCollider.enabled = false;
        }
        else
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        enemyAnimation.PlayAttackAnimation();
        boxCollider.enabled = true;

    }


}
