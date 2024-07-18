using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;
    private int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            OnHealthChanged?.Invoke(currentHealth);
            Debug.Log($"Character's Health: current health - {CurrentHealth}");
        }
    }
    private int currentHealth;

    public static event Action<int> OnHealthChanged;
    public static event Action OnDeath;

    private void Awake()
    {
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
