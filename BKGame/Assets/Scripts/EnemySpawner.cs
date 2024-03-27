using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    //Variables
    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 3f;

    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    private int currentWave;
     
    //References
    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<EnemyMeleeStats> enemyList;
    [SerializeField] private List<EnemyMeleeStats> deadEnemies;


    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }

    /*private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemiesAreDead())
                return;
            else
                CompleteWave();
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
            waveCountdown -= Time.deltaTime;
    }*/

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (enemyList.Count == 0) // Check if the enemy list is empty
                CompleteWave();
        }

        if (state == SpawnState.COUNTING) // Add this condition
        {
            if (waveCountdown <= 0)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }


    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnMeleeGrunt(wave.grunt);
            yield return new WaitForSeconds(wave.delay);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnMeleeGrunt(GameObject grunt)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];
        
        GameObject newGrunt = Instantiate(grunt, randomSpawner.position, spawners[randomInt].rotation);
        EnemyMeleeStats newGruntStats = newGrunt.GetComponent<EnemyMeleeStats>();

        enemyList.Add(newGruntStats);
    }

    /*private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(EnemyMeleeStats grunt in enemyList)
        {
            if (grunt.IsDead())
                i++;
            else
                return false;
        }
        return true;
    }*/

    private void EnemiesAreDead()
    {
        // Iterate through the enemy list
        foreach (EnemyMeleeStats grunt in enemyList)
        {
            // If an enemy is dead, add it to the deadEnemies list
            if (grunt.IsDead())
            {
                deadEnemies.Add(grunt);
            }
        }

        // Remove dead enemies from the main enemyList
        foreach (EnemyMeleeStats deadEnemy in deadEnemies)
        {
            enemyList.Remove(deadEnemy);
        }
    }


    private void CompleteWave()
    {
        Debug.Log("WAVE COMPLETED");

        state = SpawnState.COUNTING;

        waveCountdown = timeBetweenWaves;

        if(currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
            Debug.Log("Completed All The Waves");
        }
        else
        {
            currentWave++;
        }
    }
}
