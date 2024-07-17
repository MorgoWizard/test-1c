using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private float _speed;

    public void Initialize(EnemyData enemyData)
    {
        _speed = Random.Range(enemyData.MinSpeed, enemyData.MaxSpeed);
        Debug.Log("Enemy Movement: initialization complete");
    }

    private void Update()
    {
        transform.position += (Vector3)Vector2.down * (Time.deltaTime * _speed);
    }
}
