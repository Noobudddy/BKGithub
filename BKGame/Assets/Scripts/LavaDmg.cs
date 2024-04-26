using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDmg : MonoBehaviour
{
    [SerializeField] public int damage;
    public PlayerStats playerStats;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Fell in Lava");
            playerStats.TakeDamage(damage);
        }

    }
}