using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetection : MonoBehaviour
{
    public MeleeController mc;
    public Fireball fb;
    public EnemyMeleeStats ems;
    //public GameObject HitParticle;

    private int enemyLayer;

    private void Awake()
    {
        // Assign layer ID to the "Enemy" layer
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fireball entered OnTriggerEnter");

        if (other.gameObject.layer == enemyLayer)
        {
            Animator enemyAnimator = other.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Hit");
            }
            else
            {
                Debug.LogWarning("Enemy does not have an Animator component.");
            }
        }

        EnemyMeleeStats enemyStats = other.GetComponent<EnemyMeleeStats>();
        if (enemyStats != null)
        {
            if (mc != null && mc.isAttacking)
            {
                enemyStats.TakeDamage(mc.damage);
            }
        }
        else
        {
            Debug.LogWarning("Enemy does not have a EnemyMeleeStats component.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            EnemyMeleeStats enemyStats = collision.gameObject.GetComponent<EnemyMeleeStats>();
            if (enemyStats != null)
            {
                if (fb != null && fb.isAttacking)
                {
                    Debug.Log("Fireball damaged enemy");
                    enemyStats.TakeDamage(fb.damage);
                }
                else
                {
                    Debug.LogWarning("MeleeController or Fireball is not properly assigned.");
                }
            }
            else
            {
                Debug.LogWarning("Enemy does not have an EnemyMeleeStats component.");
            }
        }
    }
}
