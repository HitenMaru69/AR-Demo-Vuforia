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
    [SerializeField] HealthBar healthBar;
    [SerializeField] ParticleSystem bloodParticales;


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
            healthBar.ReduceHealth();
            bloodParticales.Play();
            if (healthBar.GetCurrentHealth() > 0)
            {
                
                rb.velocity = -transform.forward * forceSpeed;
            }
            else
            {
                EnemyDie();
            }
        
        }
    }


    public void SetRigidBodyDynamic()
    {
        rb.isKinematic = false;
    }

    private void FollowPlayer()
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance > distanceBetweenPlayerAndZombie)
            {
                Vector3 direction = player.gameObject.transform.position - transform.position;

                rb.MovePosition(rb.position + direction * enemySpeed * Time.deltaTime);

                if (direction != Vector3.zero)
                {

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
    }

    public void DisableBoxCollider()
    {
        boxCollider.enabled = false;
    }

    private void AttackPlayer()
    {

        StartCoroutine(DelayOnAnimations());
    }

    IEnumerator DelayOnAnimations()
    {
        enemyAnimation.PlayAttackAnimation();
        yield return new WaitForSeconds(1f);
        boxCollider.enabled = true;
    }

    private void EnemyDie()
    {
        Destroy(this.gameObject);
    }

}
