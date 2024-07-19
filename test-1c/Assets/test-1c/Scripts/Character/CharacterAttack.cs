using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    /// <summary>
    /// Transform of the projectile's spawn point
    /// </summary>
    [SerializeField] private Transform projectileSpawner;

    /// <summary>
    /// Fire rate in bullets per second
    /// </summary>
    [SerializeField] private float fireRate = 1f;
    
    /// <summary>
    /// Radius of the character's attack in units
    /// </summary>
    [SerializeField] private float attackRadius = 5f;
    
    /// <summary>
    /// GO prefab of the projectile
    /// </summary>
    [SerializeField] private GameObject projectilePrefab;

    /// <summary>
    /// Min time of possible shot
    /// </summary>
    private float _nextFireTime;
    
    /// <summary>
    /// Target's transform to shoot
    /// </summary>
    private Transform _target;

    private void Update()
    {
        // TODO: Find target with coroutine with cooldown for optimization
        FindTarget();
        
        if (_target)
        {
            RotateTowardsTarget();
            Attack();
        }
    }

    private void FindTarget()
    {
        Collider2D[] possibleTargets = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D possibleTarget in possibleTargets)
        {
            if (possibleTarget.TryGetComponent(out IDamageable damageable))
            {
                float distance = Vector3.Distance(transform.position, possibleTarget.transform.position);
                
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = possibleTarget.transform;
                }
            }
        }

        _target = closestEnemy;
    }

    private void Attack()
    {
        if (_target  && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        // TODO: Add object pool
        GameObject bullet = Instantiate(projectilePrefab, projectileSpawner.position, projectileSpawner.rotation);
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
