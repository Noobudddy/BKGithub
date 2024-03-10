using Mono.CSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private NavMeshAgent agent = null;
    //private Animator anim = null;
    private EnemyMeleeStats stats = null;
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;
    private Transform player;
    [SerializeField] private float stoppingDistance; 

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        agent.SetDestination(player.position);
        //anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToPlayer();
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= agent.stoppingDistance)
        {
            agent.SetDestination(transform.position);
            //anim.SetFloat("Speed", 0f);
            //Attack
            if (!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }
 
            if (Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                AttackPlayer(playerStats);
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped= false;
            }
        }
    }
    
    private void RotateToPlayer()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackPlayer(PlayerStats statsToDamage)
    {
        //anim.SetTrigger("Attack");
        stats.DealDamage(statsToDamage);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponentInChildren<Animator>();
        stats = GetComponent<EnemyMeleeStats>();
        player = PlayerMovement.instance;
    }
}
