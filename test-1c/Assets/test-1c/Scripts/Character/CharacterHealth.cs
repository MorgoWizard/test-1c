using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageable
{
    /// <summary>
    /// Max of the character's health
    /// </summary>
    [SerializeField] private int maxHealth;
    
    /// <summary>
    /// Current character's health
    /// </summary>
    private int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            OnHealthChanged?.Invoke(_currentHealth);
            Debug.Log($"Character's Health: current health - {CurrentHealth}");
        }
    }
    private int _currentHealth;

    /// <summary>
    /// The event that is triggered when the health changes
    /// </summary>
    public static event Action<int> OnHealthChanged;
    /// <summary>
    /// The event that is triggered when the character dies
    /// </summary>
    public static event Action OnDeath;

    private void Awake()
    {
        // Set the current health to the max health on game started
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"Character Health: character take {damage} damage");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Debug.Log("Character Health: character died");
    }
}
