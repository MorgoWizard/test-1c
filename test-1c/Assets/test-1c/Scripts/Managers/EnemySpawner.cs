using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;

    private bool _isSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnEnemy()
    {
        GameObject currentEnemy = enemyFactory.GetProduct().gameObject;
        Transform spawnPointTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Vector3 spawnPointPosition = spawnPointTransform.position;
        currentEnemy.transform.position = spawnPointPosition;
    }

    private IEnumerator SpawnEnemies()
    {
        while (_isSpawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(GetCooldownTime());
        }
    }

    private float GetCooldownTime()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}
