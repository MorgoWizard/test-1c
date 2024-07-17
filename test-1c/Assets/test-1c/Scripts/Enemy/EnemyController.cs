using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private EnemyMovement enemyMovement;

    public void Initialize()
    {
        Debug.Log("Enemy Controller: initialization started");
        enemyHealth.Initialize(enemyData);
        enemyMovement.Initialize(enemyData);
        Debug.Log("Enemy Controller: initialization complete");
    }
    
    
}
