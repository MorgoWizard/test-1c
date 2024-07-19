using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Enemy's speed
    /// </summary>
    private float _speed;

    #region MonoBehavior Methods

    private void Update()
    {
        transform.position += (Vector3)Vector2.down * (Time.deltaTime * _speed);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Initializes enemy movement with EnemyData
    /// </summary>
    /// <param name="enemyData">Data to use in Initialize</param>
    public void Initialize(EnemyData enemyData)
    {
        _speed = Random.Range(enemyData.MinSpeed, enemyData.MaxSpeed);
        Debug.Log("Enemy Movement: initialization complete");
    }

    #endregion
}
