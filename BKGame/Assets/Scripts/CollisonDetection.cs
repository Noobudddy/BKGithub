using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDetection : MonoBehaviour
{
    public MeleeController mc;
    //public GameObject HitParticle;

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "Enemy" && mc.isAttacking)
        {
            Debug.Log(enemy.name);
            enemy.GetComponent<Animator>().SetTrigger("Hit");
            //Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z),other.transform.rotation);
            PlayerStats enemyStats = transform.GetComponent<PlayerStats>();
            enemyStats.TakeDamage(mc.damage);
        }
    }

}
