using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    public HealthBar healthBar;

    public GameManager gameManager;

    public PlayerMovement playerMovement;
    public Sliding sliding;
    public Swinging swinging;
    public Grappling grappling;
    public PlayerCam playerCam;

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
        healthBar.SetHealth(health);
    }

    public virtual void Die()
    {
        isDead = true;
        gameManager.gameOver();
        playerMovement.enabled = false;
        sliding.enabled = false;
        swinging.enabled = false;
        grappling.enabled = false;
        playerCam.enabled = false;
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
        healthBar.SetMaxHealth(maxHealth);
    }

}
