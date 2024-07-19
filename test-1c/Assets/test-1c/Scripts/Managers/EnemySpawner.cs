using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Factory component
    /// </summary>
    [SerializeField] private EnemyFactory enemyFactory;

    /// <summary>
    /// Array of spawn points
    /// </summary>
    [SerializeField] private Transform[] spawnPoints;

    /// <summary>
    /// Min delay between spawns
    /// </summary>
    [SerializeField] private float minSpawnDelay;

    /// <summary>
    /// Max delay between spawns
    /// </summary>
    [SerializeField] private float maxSpawnDelay;

    /// <summary>
    /// Bool to control spawn
    /// </summary>
    private bool _isSpawning = true;

    #region MonoBehavior Methods

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    #endregion

    #region PrivateMethods

    /// <summary>
    /// Spawns 1 enemy at random spawn point position
    /// </summary>
    private void SpawnEnemy()
    {
        GameObject currentEnemy = enemyFactory.GetProduct().gameObject;
        Transform spawnPointTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Vector3 spawnPointPosition = spawnPointTransform.position;
        currentEnemy.transform.position = spawnPointPosition;
    }

    /// <summary>
    /// Spawns enemies with cooldown
    /// </summary>
    private IEnumerator SpawnEnemies()
    {
        while (_isSpawning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(GetCooldownTime());
        }
    }

    /// <summary>
    /// Calculates new cooldown time (random between min and max delay)
    /// </summary>
    /// <returns>New cooldown time</returns>
    private float GetCooldownTime()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    #endregion
}