using UnityEngine;

public class EnemyFactory : Factory<EnemyController>
{

    public override EnemyController GetProduct()
    {
        EnemyController currentEnemy = Instantiate(productPrefab.gameObject).GetComponent<EnemyController>();
        currentEnemy.Initialize();
        return currentEnemy;
    }
}
