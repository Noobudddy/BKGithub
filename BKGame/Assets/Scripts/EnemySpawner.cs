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

    private bool isSpawningWave = false;

    //References
    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<EnemyMeleeStats> enemyList;


    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
        isSpawningWave = true;
    }

    private void Update()
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
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        Debug.Log("Spawn State = " + state);

        for (int i = 0; i < wave.enemiesAmount; i++)
        {
            if (!isSpawningWave)
                yield break;

            SpawnMeleeGrunt(wave.grunt);
            yield return new WaitForSeconds(wave.delay);
        }

        state = SpawnState.WAITING;
        Debug.Log("Spawn State = " + state);
    }

    private void SpawnMeleeGrunt(GameObject grunt)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];
        
        GameObject newGrunt = Instantiate(grunt, randomSpawner.position, spawners[randomInt].rotation);
        EnemyMeleeStats newGruntStats = newGrunt.GetComponent<EnemyMeleeStats>();

        enemyList.Add(newGruntStats);
    }

    private bool EnemiesAreDead()
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
    }

    private void CompleteWave()
    {
        Debug.Log("WAVE COMPLETED");

        state = SpawnState.COUNTING;
        Debug.Log("Spawn State = " + state);

        waveCountdown = timeBetweenWaves;

        if (currentWave + 1 >= waves.Length)
        {
            currentWave = 0;
            isSpawningWave = false; // Ensure spawning is stopped immediately
            StopCoroutine(SpawnWave(waves[currentWave]));
            Debug.Log("Completed All The Waves");
        }
        else
        {
            currentWave++;
        }
    }
}
