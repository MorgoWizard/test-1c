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

    #region MonoBehavior Methods

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Finds the target (the nearest enemy) within the attack radius of the character
    /// </summary>
    private void FindTarget()
    {
        Collider2D[] possibleTargets = Physics2D.OverlapCircleAll(transform.position, attackRadius);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D possibleTarget in possibleTargets)
            if (possibleTarget.TryGetComponent(out IDamageable _))
            {
                float distance = Vector3.Distance(transform.position, possibleTarget.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = possibleTarget.transform;
                }
            }

        _target = closestEnemy;
    }

    /// <summary>
    /// Attack behavior
    /// </summary>
    private void Attack()
    {
        if (_target && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    /// <summary>
    /// Spawn projectile
    /// </summary>
    private void Shoot()
    {
        // TODO: Add object pool
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawner.position, projectileSpawner.rotation);
    }

    /// <summary>
    /// Rotates character towards target
    /// </summary>
    private void RotateTowardsTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    #endregion
}