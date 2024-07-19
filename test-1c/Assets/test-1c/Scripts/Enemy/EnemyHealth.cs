using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    /// <summary>
    /// Max enemy health
    /// </summary>
    private int _maxHealth;
    /// <summary>
    /// Current enemy health
    /// </summary>
    private int _currentHealth;

    /// <summary>
    /// The event that is triggered when the enemy dies
    /// </summary>
    public static event Action OnDeath;

    #region Public Methods

    /// <summary>
    /// Initializes enemy with EnemyData
    /// </summary>
    /// <param name="enemyData">Data to use in Initialzie</param>
    public void Initialize(EnemyData enemyData)
    {
        _maxHealth = enemyData.MaxHealth;
        _currentHealth = _maxHealth;
        Debug.Log("Enemy Health: Initialization complete");
    }

    /// <summary>
    /// Takes damage by amount
    /// </summary>
    /// <param name="damage">Damage amount</param>
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Enemy Health: take {damage} damage");
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Behavior on death
    /// </summary>
    private void Die()
    {
        Debug.Log("Enemy Health: entity died");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    #endregion
}
