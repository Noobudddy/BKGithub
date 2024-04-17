using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    public GameManager gameManager;

    private void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            Die();
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
        //gameObject.SetActive(false);
        gameManager.gameOver();
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public virtual void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealthTo(healthAfterHeal);
    }

    public virtual void InitVariables()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;
    }

}
