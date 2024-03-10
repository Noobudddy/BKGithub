using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;

    [SerializeField] private GameObject meleeGrunt;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnMeleeGrunt();
        }
    }

    private void SpawnMeleeGrunt()
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];
        
        Instantiate(meleeGrunt, randomSpawner.position, spawners[randomInt].rotation);
    }
}
