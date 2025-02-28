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


    private void Start()
    {
        boxCollider.enabled = false;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Axe")
        {
            Debug.Log("Player Attack");
            // add logic for kill Zombies
        }
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
