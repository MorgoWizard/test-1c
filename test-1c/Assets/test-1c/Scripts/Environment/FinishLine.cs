using UnityEngine;

public class FinishLine : MonoBehaviour
{
    /// <summary>
    /// Damage amount per enemy
    /// </summary>
    [SerializeField] private int damagePerEnemy;

    /// <summary>
    /// Character's health component
    /// </summary>
    [SerializeField] private CharacterHealth characterHealth;

    #region MonoBehavior Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            characterHealth.TakeDamage(damagePerEnemy);
            Destroy(collision.gameObject);
        }
    }

    #endregion
}