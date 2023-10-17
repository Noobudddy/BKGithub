using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetection : MonoBehaviour
{
    public MeleeController mc;
    public EnemyMeleeStats ems;
    //public GameObject HitParticle;

    public LayerMask enemyLayer;

    private void Awake()
    {
        // Assign layer ID to the "Enemy" layer
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnTriggerEnter(Collider other)
    {
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
        
            EnemyMeleeStats enemyStats = other.GetComponent<EnemyMeleeStats>();
            if (enemyStats != null)
            {
                if (mc != null && mc.isAttacking)
                {
                    enemyStats.TakeDamage(mc.damage);
                }
            }
        }   
        else
        {
            Debug.LogWarning("Enemy does not have a 'Enemy' layer.");
        }
    }
}
