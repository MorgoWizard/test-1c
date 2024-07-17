using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private int _maxHealth;
    private int _currentHealth;

    public void Initialize(EnemyData enemyData)
    {
        _maxHealth = enemyData.MaxHealth;
        _currentHealth = _maxHealth;
        Debug.Log("Enemy Health: Initialization complete");
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Enemy Health: take {damage} damage");
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Health: entity died");
        Destroy(gameObject);
    }
}
