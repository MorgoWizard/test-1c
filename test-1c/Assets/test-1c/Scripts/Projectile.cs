using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// Damage amount of projectile
    /// </summary>
    [SerializeField] private int projectileDamage = 10;

    /// <summary>
    /// Projectile's speed
    /// </summary>
    [SerializeField] private float speed = 10f;

    #region MonoBehavior Methods

    private void Update()
    {
        transform.position += transform.right * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out IDamageable enemyHealth))
        {
            enemyHealth.TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    #endregion
}