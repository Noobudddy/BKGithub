using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetection : MonoBehaviour
{
    public MeleeController mc;
    //public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && mc.isAttacking)
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

            PlayerStats enemyStats = other.GetComponent<PlayerStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(mc.damage);
            }
            else
            {
                Debug.LogWarning("Enemy does not have a PlayerStats component.");
            }
        }
    }

}
