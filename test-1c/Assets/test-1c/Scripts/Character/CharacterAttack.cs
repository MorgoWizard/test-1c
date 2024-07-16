using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawner;

    public float fireRate = 1f;
    public float attackRadius = 5f;
    public GameObject bulletPrefab;

    private float nextFireTime = 0f;
    private Transform target;

    private void Update()
    {
        // TODO: Find target with courutine with cooldown
        FindTarget();
        if (target != null)
        {
            RotateTowardsTarget();
            Attack();
        }
    }

    private void FindTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.transform;
                }
            }
        }

        target = closestEnemy;
    }

    private void Attack()
    {
        if (target != null && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        // TODO: Add object pool
        GameObject bullet = Instantiate(bulletPrefab, projectileSpawner.position, projectileSpawner.rotation);
    }

    private void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
