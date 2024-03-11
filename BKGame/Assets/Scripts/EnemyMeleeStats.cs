using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeStats : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] protected int maxHealth;
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy was damaged");
        int healthAfterDamage = health -= damage;
        SetHealthTo(healthAfterDamage);
    }

    public void DealDamage(PlayerStats statsToDamage)
    {
        Debug.Log("Player was damaged");
        statsToDamage.TakeDamage(damage);
    }

    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealthTo(healthAfterHeal);
    }

    public void InitVariables()
    {
        maxHealth = 50;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
    }
}
