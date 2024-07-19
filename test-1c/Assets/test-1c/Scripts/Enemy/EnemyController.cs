using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// Data to enemy initialization
    /// </summary>
    [SerializeField] private EnemyData enemyData;

    /// <summary>
    /// Enemy Health System component
    /// </summary>
    [SerializeField] private EnemyHealth enemyHealth;

    /// <summary>
    /// Enemy Movement System component
    /// </summary>
    [SerializeField] private EnemyMovement enemyMovement;

    #region Private Methods

    /// <summary>
    /// Initializes enemy
    /// </summary>
    public void Initialize()
    {
        Debug.Log("Enemy Controller: initialization started");
        enemyHealth.Initialize(enemyData);
        enemyMovement.Initialize(enemyData);
        Debug.Log("Enemy Controller: initialization complete");
    }

    #endregion
}