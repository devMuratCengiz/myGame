using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", .5f, 1f);
    }

    public void SpawnEnemy()
    {
        int randomPrefabs = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randomPrefabs], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
