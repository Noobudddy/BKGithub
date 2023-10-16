using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeStats : PlayerStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;

    private void Start()
    {
        InitVariables();
    }

    public void DealDamage(PlayerStats statsToDamage)
    {
        Debug.Log("Player was damaged");
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

    public override void InitVariables()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
    }
}
